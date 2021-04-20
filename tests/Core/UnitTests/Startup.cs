using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.UnitTests
{
	
	[TestClass]
	public class Startup
	{

		private static ServiceProvider _serviceProvider;

		[AssemblyInitialize]
		public static void Initialise(TestContext testContext)
		{
			ServiceCollection services;

			services = new ServiceCollection();

			// Initialise CSLA to the point where data access is possible using the in-memory repository
			services.AddValidationInMemoryRepositories();

			CslaConfiguration.Configure().
				DataPortal().DefaultProxy(typeof(Csla.DataPortalClient.LocalProxy), "");
			services.AddCsla();
			
			_serviceProvider = services.BuildServiceProvider();

			CslaConfiguration.Configure().ServiceProviderScope(_serviceProvider);

		}

	}
}
