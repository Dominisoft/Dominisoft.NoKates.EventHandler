using System;
using System.Collections.Generic;
using System.Text;
using Dominisoft.Nokates.Common.Models;

namespace Dominisoft.NoKates.EventHandler.Common.Models
{
    public class Listener:Entity    
    {
        public string Name { get; set; }
        public int QueueIndex { get; set; }

    }
}
