using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Common.Models;

namespace Dominisoft.NoKates.EventHandler.Common.Models
{
    [DefaultConnectionString("Events")]
    [Table("Events")]
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
