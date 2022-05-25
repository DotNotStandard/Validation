/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNotStandard.Validation.Core
{

	/// <summary>
	/// Configuration entrypoint for the validation subsystem
	/// </summary>
	public class ValidationSubsystem
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly ICharacterSetListCache _characterSetListCache;
		private readonly IDisallowedFragmentListCache _disallowedFragmentListCache;

        #region Constructors

        public ValidationSubsystem(IServiceProvider serviceProvider)
        {
			_serviceProvider = serviceProvider;
			_characterSetListCache = serviceProvider.GetRequiredService<ICharacterSetListCache>();
			_disallowedFragmentListCache = serviceProvider.GetRequiredService<IDisallowedFragmentListCache>();
		}

		#endregion

		#region Factory Methods

		/// <summary>
		/// Initialise the validation subsystem, waiting for completion
		/// </summary>
		/// <remarks>
		/// Note that this method blocks until initialisation is complete. If there is a chance that 
		/// your data source will be unavailable and your system will work without validation then use 
		/// of the StartInitialisation and TryCompleteInitialisation methods may be more appropriate
		/// </remarks>
		/// <param name="serviceProvider">The service provider to use in initialisation</param>
		/// <returns>The instance of the validation subsystem that was initialised</returns>
		public static ValidationSubsystem Initialise(IServiceProvider serviceProvider)
        {
			ValidationSubsystem validationSubsystem;

			validationSubsystem = serviceProvider.GetRequiredService<ValidationSubsystem>();
			validationSubsystem.Initialise();

			return validationSubsystem;
        }

		/// <summary>
		/// Start background initialisation of the validation subsystem and then return.
		/// </summary>
		/// <remarks>
		/// This method returns before initialisation is complete, allowing other processing to 
		/// continue in the meantime. Call TryCompleteInitialisation at the last possible moment to
		/// try to ensure that initialisation has been completed
		/// </remarks>
		public static ValidationSubsystem StartInitialisation(IServiceProvider serviceProvider)
		{
			ValidationSubsystem validationSubsystem;

			validationSubsystem = serviceProvider.GetRequiredService<ValidationSubsystem>();
			validationSubsystem.StartInitialisation();

			return validationSubsystem;
		}

		#endregion

		#region Initialisation

		/// <summary>
		/// Initialise the subsystem so that it is ready for use.
		/// </summary>
		/// <remarks>
		/// Note that this method blocks until initialisation is complete. If there is a chance that 
		/// your data source will be unavailable and your system will work without validation then use 
		/// of the StartInitialisation and TryCompleteInitialisation methods may be more appropriate
		/// </remarks>
		public void Initialise()
		{
			if (_characterSetListCache is ICharacterSetListCacheInitialiser cscacheInitialiser)
				cscacheInitialiser.Initialise();
			if (_disallowedFragmentListCache is IDisallowedFragmentListCacheInitialiser dfcacheInitialiser)
				dfcacheInitialiser.Initialise();
		}

		/// <summary>
		/// Start background initialisation of the validation subsystem and then return.
		/// </summary>
		/// <remarks>
		/// This method returns before initialisation is complete, allowing other processing to 
		/// continue in the meantime. Call TryCompleteInitialisation at the last possible moment to
		/// try to ensure that initialisation has been completed
		/// </remarks>
		public void StartInitialisation()
		{
			if (_characterSetListCache is ICharacterSetListCacheInitialiser cscacheInitialiser)
				cscacheInitialiser.StartInitialisation();
			if (_disallowedFragmentListCache is IDisallowedFragmentListCacheInitialiser dfcacheInitialiser)
				dfcacheInitialiser.StartInitialisation();
		}

		/// <summary>
		/// Attempt to wait for initialisation to complete, using a timeout to avoid permanently
		/// blocking further progress of the consuming application.
		/// </summary>
		/// <param name="timeout">The timeout to apply before returning if validation fails to initialise</param>
		/// <returns>Boolean true if the initialisation completes successfully, otherwise false</returns>
		public bool TryCompleteInitialisation(TimeSpan timeout)
		{
			bool isInitialised;
			DateTime startedAt;
			TimeSpan remainingTimeout;

			if (!(_characterSetListCache is ICharacterSetListCacheInitialiser cscacheInitialiser)) return false;
			if (!(_disallowedFragmentListCache is IDisallowedFragmentListCacheInitialiser dfcacheInitialiser)) return false;

			startedAt = DateTime.Now;
			isInitialised = cscacheInitialiser.TryCompleteInitialisation(timeout);
			if (isInitialised)
            {
				remainingTimeout = DateTime.Now - startedAt;
				isInitialised = dfcacheInitialiser.TryCompleteInitialisation(remainingTimeout);
			}

			return isInitialised;
		}

		#endregion

    }
}
