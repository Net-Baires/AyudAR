using System;

namespace server.Model
{
    public class NewDriver {
        public Guid Id { get; private set; }
        public NewDriver()
        {
            this.Id = Guid.NewGuid();
        }
        public Driver Driver { get; set; }
    }

}
