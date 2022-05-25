/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core
{
    /// <summary>
    /// Standard implementation of a character set repository factory, which uses
    /// DI to create instances of the repository as necessary
    /// </summary>
    internal class DICharacterSetRepositoryFactory : ICharacterSetRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DICharacterSetRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICharacterSetRepository CreateCharacterSetRepository()
        {
            return _serviceProvider.GetRequiredService<ICharacterSetRepository>();
        }
    }
}
