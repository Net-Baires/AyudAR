using System;

namespace server.Model
{
    public class RecalculateRoutesMessage {
        public string Type { get; set; }
        public Guid Id { get; set; }
    }

}
