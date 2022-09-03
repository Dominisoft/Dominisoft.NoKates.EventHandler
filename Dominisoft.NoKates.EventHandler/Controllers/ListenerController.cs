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

        [HttpGet("Index/{name}")]
        [NoAuth]
        public int GetListenerIndex(string name)
        {
            return GetListenerByName(name)?.QueueIndex ?? -1;
        }
        [HttpPost("Index/{name}/{index}")]
        [NoAuth]
        public bool SetListenerIndex(string name,int index)
        {
            var l = GetListenerByName(name);
            l.QueueIndex = index;
            var l2 = Repository.Update(l);
            return l.QueueIndex == l2.QueueIndex;

        }
        [HttpGet("Index")]
        [NoAuth]
        public int GetLastIndex()
        {
            return Repository.GetAll()?.Max(l => l.QueueIndex)??0;
        }
        [HttpGet("ByName/{name}")]
        [NoAuth]
        public Listener GetListenerByName(string name)
        {
            return Repository.GetAll().FirstOrDefault(l => l.Name == name);
        }

    }
}
