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
	public class ValidationSubsystem
	{
		private static IServiceProvider _serviceProvider;

        #region Constructors

        private ValidationSubsystem()
        {
			// Disallow instantiation of the type
        }

        #endregion

        #region Exposed Properties and Methods

        public static T GetRequiredService<T>()
        {
			return _serviceProvider.GetRequiredService<T>();
        }

		public static ILogger GetLogger()
		{
			return _serviceProvider.GetRequiredService<ILogger<ValidationSubsystem>>();
		}

		public static void Initialise(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			CharacterSetList.Initialise();
			DisallowedFragmentList.Initialise();
		}

        #endregion

    }
}
