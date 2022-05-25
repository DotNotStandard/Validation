/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core.UnitTests
{
    [TestClass]
    public class InitialisationTests
    {

        [TestMethod]
        public void TryCompleteInitialisation_InMemoryRepositories_InitialisesCorrectly()
        {
            // Arrange
            IServiceCollection services;
            IServiceProvider serviceProvider;
            bool expected = true;
            bool actual;

            services = new ServiceCollection();
            services.AddLogging();
            services.AddValidationSubsystem();
            services.AddValidationInMemoryRepositories();
            serviceProvider = services.BuildServiceProvider();

            // Act
            var subsystem = ValidationSubsystem.StartInitialisation(serviceProvider);
            actual = subsystem.TryCompleteInitialisation(TimeSpan.FromSeconds(2));

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TryCompleteInitialisation_FakeBlockingRepositories_InitialisationTimesOut()
        {
            // Arrange
            IServiceCollection services;
            IServiceProvider serviceProvider;
            bool expected = false;
            bool actual;

            services = new ServiceCollection();
            services.AddLogging();
            services.AddValidationSubsystem();
            services.AddTransient<ICharacterSetRepository, Fakes.FakeBlockingCharacterSetRepository>();
            services.AddTransient<IDisallowedFragmentRepository, Fakes.FakeBlockingDisallowedFragmentRepository>();
            serviceProvider = services.BuildServiceProvider();

            // Act
            var subsystem = ValidationSubsystem.StartInitialisation(serviceProvider);
            actual = subsystem.TryCompleteInitialisation(TimeSpan.FromSeconds(2));

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
