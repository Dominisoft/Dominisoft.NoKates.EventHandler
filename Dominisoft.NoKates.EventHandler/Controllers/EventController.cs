using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Common.Infrastructure.Configuration;
using Dominisoft.Nokates.Common.Infrastructure.Controllers;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;
using Dominisoft.Nokates.Common.Models;
using Dominisoft.NoKates.EventHandler.Common.Models;
using Microsoft.AspNetCore.Mvc;
using file = System.IO.File;

namespace Dominisoft.Nokates.EventHandler.Controllers
{
    [Route("[controller]")]

    public class EventController : BaseController<EventMessage>
    {
        public EventController() : base(RepositoryHelper.CreateRepository<EventMessage>())
        { }

    }
}
