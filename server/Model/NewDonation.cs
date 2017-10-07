using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Model
{

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
        public Availability Availability { get; set; }
        public List<Package> Packages { get; set; }
    }

}
