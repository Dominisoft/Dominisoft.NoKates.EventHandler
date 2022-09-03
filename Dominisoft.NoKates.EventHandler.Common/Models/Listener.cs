using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Common.Models;

namespace Dominisoft.NoKates.EventHandler.Common.Models
{
    [DefaultConnectionString("Events")]
    [Table("MQ_Listeners")]
    public class Listener:Entity    
    {
        public string Name { get; set; }
        public int QueueIndex { get; set; }

    }
}
