﻿/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Caching.Core.InMemory;
using DotNotStandard.Validation.Core.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core
{
    internal class DisallowedFragmentListCache : IDisallowedFragmentListCache, IDisallowedFragmentListCacheInitialiser
    {
        private AutoRefreshingItemCache<DisallowedFragmentList> _cache;
        private readonly IServiceProvider _serviceProvider;

        #region Constructors

        public DisallowedFragmentListCache(ILogger<DisallowedFragmentListCache> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _cache = new AutoRefreshingItemCache<DisallowedFragmentList>(
                logger,
                GetListToCacheAsync,
                new DisallowedFragmentList(),
                TimeSpan.FromMinutes(120)
                );
        }

        #endregion

        #region Exposed Properties and Methods

        #region Initialisation

        /// <summary>
        /// Initialise the underlying cache so that it is ready for use.
        /// </summary>
        /// <remarks>
        /// Note that this method blocks until initialisation is complete. If there is a chance that 
        /// the data source will be unavailable then use of the alternative StartInitialisation and 
        /// TryCompleteInitialisation methods may be more appropriate
        /// </remarks>
        void IDisallowedFragmentListCacheInitialiser.Initialise()
        {
            _cache.Initialise();
        }

        /// <summary>
        /// Start background initialisation of the underlying cache and then return.
        /// </summary>
        /// <remarks>
        /// This method returns before initialisation is complete, allowing other processing to 
        /// continue in the meantime. Call TryCompleteInitialisation at the last possible moment to
        /// try to ensure that initialisation has been completed</remarks>
        void IDisallowedFragmentListCacheInitialiser.StartInitialisation()
        {
            _cache.StartInitialisation();
        }

        /// <summary>
        /// Attempt to wait for initialisation to complete, using a timeout to avoid permanently
        /// blocking further progress of the consuming application.
        /// </summary>
        /// <param name="timeout">The timeout to apply before returning if validation fails to initialise</param>
        /// <returns>Boolean true if the initialisation completes successfully, otherwise false</returns>
        bool IDisallowedFragmentListCacheInitialiser.TryCompleteInitialisation(TimeSpan timeout)
        {
            return _cache.TryCompleteInitialisation(timeout);
        }

        #endregion

        /// <summary>
        /// Get the list from the underlying cache
        /// </summary>
        /// <returns>The disallowed fragment list returned by the cache</returns>
        public DisallowedFragmentList GetDisallowedFragmentList()
        {
            return _cache.GetItem();
        }

        /// <summary>
        /// Get the list from the underlying cache
        /// </summary>
        /// <returns>The disallowed fragment list returned by the cache</returns>
        public Task<DisallowedFragmentList> GetDisallowedFragmentListAsync()
        {
            return Task.FromResult(_cache.GetItem());
        }

        #endregion

        #region Cache Update Methods

        /// <summary>
        /// Background method used to load the contents of the cache, initiated by the cache
        /// at the appropriate times
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for use in cancelling the operation</param>
        /// <returns>The list to be placed into the cache</returns>
        private async Task<DisallowedFragmentList> GetListToCacheAsync(CancellationToken cancellationToken)
        {
            IDisallowedFragmentRepository repository;
            DisallowedFragmentList list;

            list = new DisallowedFragmentList();
            repository = _serviceProvider.GetRequiredService<IDisallowedFragmentRepository>();
            await list.LoadListAsync(repository);
            return list;
        }

        #endregion

    }
}
