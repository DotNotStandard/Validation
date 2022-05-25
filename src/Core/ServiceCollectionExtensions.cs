/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core;
using DotNotStandard.Validation.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for the IServiceCollection type
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register the validation subsystem for use in an application
        /// </summary>
        /// <param name="services">The service collection we are extending</param>
        /// <returns>The service collection extended, to support nethod chaining</returns>
        public static IServiceCollection AddValidationSubsystem(this IServiceCollection services)
        {
            services.AddSingleton<ValidationSubsystem>();
            services.AddSingleton<ICharacterSetListCache, CharacterSetListCache>();
            services.AddSingleton<IDisallowedFragmentListCache, DisallowedFragmentListCache>();
            services.AddSingleton<ICharacterSetRepositoryFactory, DICharacterSetRepositoryFactory>();
            services.AddSingleton<IDisallowedFragmentRepositoryFactory, DIDisallowedFragmentRepositoryFactory>();
            services.AddTransient<CharacterSetValidator>();

            return services;
        }
    }
}
