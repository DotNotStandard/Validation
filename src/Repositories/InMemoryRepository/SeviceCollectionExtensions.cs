/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core.DataAccess;
using DotNotStandard.Validation.Repositories.InMemoryRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class SeviceCollectionExtensions
	{

		public static void AddValidationInMemoryRepositories(this IServiceCollection services)
		{
			// Register all of the in-memory repositories that may be required
			services.AddTransient<ICharacterSetRepository, CharacterSetRepository>();
			services.AddTransient<IDisallowedFragmentRepository, DisallowedFragmentRepository>();
		}
	}
}
