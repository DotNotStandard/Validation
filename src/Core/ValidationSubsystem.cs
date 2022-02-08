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

namespace DotNotStandard.Validation.Core
{
	public static class ValidationSubsystem
	{

		public static async Task InitialiseAsync()
		{
			DataPortalConfig.ForceToAsyncOnly();
			_ = await CharacterSetList.GetCharacterSetListAsync();
			_ = await DisallowedFragmentList.GetDisallowedFragmentListAsync();
		}

	}
}
