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

// Generated from the built-in Scriban RepositoryInterface template

namespace DotNotStandard.Validation.Core.DataAccess
{
	public interface IDisallowedFragmentRepository
	{

		IList<DisallowedFragmentDTO> FetchList();

		Task<IList<DisallowedFragmentDTO>> FetchListAsync();

	}
}