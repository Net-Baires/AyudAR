using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using server.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace server
{
    public class ApiManager
    {
        private static TelemetryClient telemetry = new TelemetryClient();
        private static string key = TelemetryConfiguration.Active.InstrumentationKey = System.Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY", EnvironmentVariableTarget.Process);

        //[FunctionName("OnRecalculateRoutes")]
        //public static async Task OnRecalculateRoutes(
        //    [QueueTrigger("recalculate-routes")] RecalculateRoutesMessage message,
        //    IBinder binder,
        //    ExecutionContext context,
        //    TraceWriter log)
        //{
        //    telemetry.Context.Operation.Id = context.InvocationId.ToString();

        //}

        [FunctionName("drivers")]
        public static async Task<HttpResponseMessage> CreateDriver(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req,
            Binder binder,
            [Queue(queueName: "recalculate-routes")] IAsyncCollector<RecalculateRoutesMessage> collector,
            ExecutionContext context,
            TraceWriter log)
        {

            var newDriver = await req.Content.ReadAsAsync<NewDriver>();
            await binder.SaveBlobAsync(newDriver, $"drivers/{newDriver.Id}.json");
            await collector.AddAsync(new RecalculateRoutesMessage { Type = "Driver", Id = newDriver.Id });

            return req.CreateResponse(HttpStatusCode.OK, newDriver);

        }

        [FunctionName("donations")]
        public static async Task<HttpResponseMessage> CreateDonation(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req,
            Binder binder,
            [Queue(queueName: "recalculate-routes")] IAsyncCollector<RecalculateRoutesMessage> collector,
            ExecutionContext context,
            TraceWriter log)
        {
            telemetry.Context.Operation.Id = context.InvocationId.ToString();
            var newDonation = await req.Content.ReadAsAsync<NewDonation>();

            //TODO add validations
            //if (newIncident.Location == null) return req.CreateResponse(HttpStatusCode.BadRequest, "Missing location object");
            //if (string.IsNullOrEmpty(newIncident.Location.Key)) return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing location key. Read from company table stripe property");
            //if (string.IsNullOrEmpty(newIncident.Location.Id)) return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing location Id. Read from current user");
            //if (string.IsNullOrEmpty(newIncident.Location.Name)) return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing location name. Read from current user");
            //if (newIncident.Location.Lat == 0) return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing location latitude. Read from device");
            //if (newIncident.Location.Long == 0) return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing location longitude. Read from device");

            await binder.SaveBlobAsync(newDonation, $"donations/{newDonation.Id}.json");
            await collector.AddAsync(new RecalculateRoutesMessage { Type = "Donation", Id = newDonation.Id });

            telemetry.TrackEvent("NewDriver");

            return req.CreateResponse(HttpStatusCode.OK, newDonation);
        }

    }

    public static class Extensions
    {
        public static async Task<T> ReadTo<T>(this TextReader reader)
        {
            if (reader == null) return default(T);

            var blobContent = await reader.ReadToEndAsync();

            if (string.IsNullOrEmpty(blobContent))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(blobContent);


        }

        public static async Task<bool> BlobExistAsync(this IBinder binder, string name)
        {

            using (var reader = await binder.BindAsync<TextReader>(
                  new BlobAttribute(name)))
            {
                return reader != null;
            }
        }

        public static async Task<T> ReadBlobAsync<T>(this IBinder binder, string name)
        {
            var blobContent = string.Empty;

            using (var reader = await binder.BindAsync<TextReader>(
                  new BlobAttribute(name)))
            {
                if (reader != null)
                {
                    blobContent = await reader.ReadToEndAsync();
                }
            }


            if (string.IsNullOrEmpty(blobContent))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(blobContent);



        }

        public static async Task SaveBlobAsync<T>(this IBinder binder, T input, string name)
        {

            using (var writer = await binder.BindAsync<TextWriter>(
                new BlobAttribute(name)))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(input));
            }
        }
    }

}