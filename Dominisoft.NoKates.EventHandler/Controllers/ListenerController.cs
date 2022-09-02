using System.Linq;
using Dominisoft.Nokates.Common.Infrastructure.Attributes;
using Dominisoft.Nokates.Common.Infrastructure.Controllers;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;
using Dominisoft.NoKates.EventHandler.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dominisoft.NoKates.EventHandler.Controllers
{
    [Route("[controller]")]

    public class ListenerController : BaseController<Listener>
    {
        public ListenerController() : base(RepositoryHelper.CreateRepository<Listener>())
        { }

        [HttpGet("/Index/{name}")]
        [NoAuth]
        public int GetListenerIndex(string name)
        {
            return Repository.GetAll().FirstOrDefault(l => l.Name == name)?.QueueIndex??-1;
        }
    }
}
