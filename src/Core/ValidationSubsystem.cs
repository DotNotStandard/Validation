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
