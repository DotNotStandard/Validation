/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core.UnitTests
{
	
	public class ValidationTestFactory
	{

		private readonly IServiceProvider _serviceProvider;
		private readonly ValidationSubsystem _validationSubsystem;

        #region Constructors

        private ValidationTestFactory(IServiceProvider serviceProvider, ValidationSubsystem validationSubsystem)
        {
			_serviceProvider = serviceProvider;
			_validationSubsystem = validationSubsystem;
        }

        #endregion

        #region Factory Method

        public static ValidationTestFactory InitialiseValidation()
		{
			IServiceProvider serviceProvider;
			ServiceCollection services;
			ValidationSubsystem validationSubsystem;

			services = new ServiceCollection();

			services.AddLogging();

			// Initialise validation to the point where data access is possible using the in-memory repository
			services.AddValidationSubsystem();
			services.AddValidationInMemoryRepositories();

			serviceProvider = services.BuildServiceProvider();
			validationSubsystem = ValidationSubsystem.Initialise(serviceProvider);

			return new ValidationTestFactory(serviceProvider, validationSubsystem);
		}

		#endregion

		#region Exposed Properties and Methods

		public IServiceProvider GetServiceProvider() => _serviceProvider;

        /// <summary>
        /// Retrieve an instance of a character set validator for use in validation
        /// </summary>
        /// <returns>An instance of CharacterSetValidator for use in validating character sets</returns>
        public CharacterSetValidator GetCharacterSetValidator()
		{
			return _serviceProvider.GetRequiredService<CharacterSetValidator>();
		}

        #endregion

    }
}
