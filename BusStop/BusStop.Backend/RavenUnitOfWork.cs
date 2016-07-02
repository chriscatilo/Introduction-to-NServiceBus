using NServiceBus.UnitOfWork;
using Raven.Client;
using System;

namespace BusStop.Backend
{
    public class RavenUnitOfWork : IManageUnitsOfWork
    {
        private readonly IDocumentSession _session;

        public RavenUnitOfWork(IDocumentSession session)
        {
            _session = session;
        }

        public void Begin()
        {
        }

        public void End(Exception ex = null)
        {
            if (ex != null) 
                _session.SaveChanges();
        }
    }
}