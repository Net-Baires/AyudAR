using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Model
{
    public class RecalculateRoutesMessage {
        public string Type { get; set; }
        public Guid Id { get; set; }
    }

    public class NewDonation
    {
        public Guid Id { get; private set; }
        public NewDonation()
        {
            this.Id = Guid.NewGuid();
        }

        public string Device { get; set; }
        public Who WhoIs { get; set; }
        public Address CollectAddress { get; set; }
        public Availablity Schedule { get; set; }
    }

    public class NewDriver {
        public Guid Id { get; private set; }
        public NewDriver()
        {
            this.Id = Guid.NewGuid();
        }
        public Driver Driver { get; set; }
    }

    public class Donation {
        public string Device { get; set; }
        public Who WhoIs { get; set; }
        public Address CollectAddress { get; set; }
        public Availablity Schedule { get; set; }
        public Driver Driver { get; set; }
        public DonationStatus DonationStatus { get; set; }

        public CollectTime CollectTime { get; set; }

    }

    public enum DonationStatus {
        Pending,
        InTransit,
        Delivered,
    }

    public class Driver {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialNumber { get; set; }
        public string CollectZone { get; set; }
        public Availablity Availablity { get; set; }
    }

    public class Package
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public Genre Genre { get; set; }

    }

    public enum Genre
    {
        Male, Female, Unisex
    }

    public class Who
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }

    public class Availablity
    {
        public List<TimeRange> Schedule { get; set; }
    }

    public class TimeRange
    {
        public string Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

    public class CollectTime {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

}
