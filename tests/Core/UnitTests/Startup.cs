/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

			services.AddLogging();

			// Initialise validation to the point where data access is possible using the in-memory repository
			services.AddValidationInMemoryRepositories();

			_serviceProvider = services.BuildServiceProvider();

			ValidationSubsystem.Initialise(_serviceProvider);

		}

	}
}
