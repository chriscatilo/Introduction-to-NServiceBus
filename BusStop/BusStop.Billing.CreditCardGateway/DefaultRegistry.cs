using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;

namespace BusStop.Billing.CreditCardGateway
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Action<IAssemblyScanner> scans = scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();

                scan.Assembly("BusStop.Authentication");
            };

            Scan(scans);
            
            For<ICreditCardService>().Use<DefaultCreditCardService>();
        }

        #endregion
    }
}