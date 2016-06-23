﻿using BusStop.Contracts;
using NServiceBus;
using Raven.Client.Document;
using System;

namespace BusStop.Backend
{
    public class PlaceHolderHandler : IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            var store = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Default"	// default database
            };

            store.Initialize();

            using (var session = store.OpenSession())
            {
                session.Store(new Order
                {
                    OrderId = message.OrderId
                });

                session.SaveChanges();
            }

            Console.WriteLine("Order received " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }

}
