using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Dominisoft.Nokates.Common.Infrastructure.Helpers;
using Dominisoft.NoKates.EventHandler.Common.Models;

namespace Dominisoft.NoKates.EventHandler.Common.Clients
{
    public class EventClient: IEventClient
    {
        private readonly string _serviceRootUri;

        public EventClient(string serviceRootUri)
        {
            _serviceRootUri = serviceRootUri;
        }

        public string RegisterListener(string name)
        {
            if (GetListener(name)==null)
            {
                HttpHelper.Post($"{_serviceRootUri}/EventHandler/Listener/Create",
                    new Listener { Name = name, QueueIndex = GetLastIndex() });
                return "Registered";
            };
            return "Already Registered";
        }


        public Listener GetListener(string name)
            => HttpHelper.Get<Listener>($"{_serviceRootUri}/EventHandler/Listener/ByName/{name}");

        public int GetListenerIndex(string name)
            => HttpHelper.Get<int>($"{_serviceRootUri}/EventHandler/Listener/Index/{name}");


        public int GetLastIndex()
            => HttpHelper.Get<int>($"{_serviceRootUri}/EventHandler/Listener/Index");


        public string SetListenerIndex(string name, int index)
            => HttpHelper.Post($"{_serviceRootUri}/EventHandler/Listener/Index/{name}/{index}");


        public List<EventMessage> GetEvents(string listenerName, bool updateIndex)
        {
            var listener = GetListener(listenerName);
            var events = GetEventsSince(listener.QueueIndex);
            if (updateIndex)
            {
                SetListenerIndex(listenerName, events.Max(e => e.Id));
            }
            return events;
        }


        public List<EventMessage> GetEventsSince(int index)
            => HttpHelper.Get<List<EventMessage>>($"{_serviceRootUri}/EventHandler/Event/After/{index}",  string.Empty);

        public string PublishEvent(EventMessage message)
            => HttpHelper.Post($"{_serviceRootUri}/EventHandler/Event/Create", message);

    }

    public interface IEventClient
    {
        string RegisterListener(string name);
        Listener GetListener(string name);
        int GetListenerIndex(string name);
        int GetLastIndex();
        string SetListenerIndex(string name, int index);
        List<EventMessage> GetEvents(string listenerName, bool updateIndex);
        List<EventMessage> GetEventsSince(int index);
        string PublishEvent(EventMessage message);

    }
}
