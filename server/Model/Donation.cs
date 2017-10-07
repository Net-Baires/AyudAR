namespace server.Model
{
    public class Donation {
        public string Device { get; set; }
        public Who WhoIs { get; set; }
        public Address CollectAddress { get; set; }
        public Availability Schedule { get; set; }
        public Driver Driver { get; set; }
        public DonationStatus DonationStatus { get; set; }

        public CollectTime CollectTime { get; set; }

    }

}
