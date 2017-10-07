using System.Threading.Tasks;
using System;
using Microsoft.ApplicationInsights;

namespace server
{
    public static class TelemetryClientExtensions
    {
        public static void TrackDependency(this TelemetryClient client, string name, string command, Action method)
        {
            var start = DateTime.UtcNow;
            method();
            client.TrackDependency(name, command, start, DateTime.UtcNow - start, true);
        }

        public static T TrackDependency<T>(this TelemetryClient client, string name, string command, Func<T> method)
        {
            var start = DateTime.UtcNow;
            var result = method();
            client.TrackDependency(name, command, start, DateTime.UtcNow - start, true);
            return result;
        }

        public static async Task TrackDependencyAsync(this TelemetryClient client, string name, string command, Func<Task> method)
        {
            var start = DateTime.UtcNow;
            await method();
            client.TrackDependency(name, command, start, DateTime.UtcNow - start, true);
        }

        public static async Task<T> TrackDependencyAsync<T>(this TelemetryClient client, string name, string command, Func<Task<T>> method)
        {
            var start = DateTime.UtcNow;
            var result = await method();
            client.TrackDependency(name, command, start, DateTime.UtcNow - start, true);

            return result;
        }


    }
    
}