using System;
using System.Collections.Generic;
using System.Text;
using Dominisoft.Nokates.Common.Models;

namespace Dominisoft.NoKates.EventHandler.Common.Models
{
    public class EventMessage:Entity
    {
        public DateTime EventTime { get; set; }
        public string Domain { get; set; }
        public string EntityName { get; set; }
        public string EventName { get; set; }
        public string Entity { get; set; }
        public string AdditionalDetails { get; set; }

    }
}
