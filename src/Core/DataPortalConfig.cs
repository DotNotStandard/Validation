using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core
{

	internal static class DataPortalConfig
	{

		internal static void ForceToAsyncOnly()
		{
			IsAsyncOnly = true;
		}

		public static bool IsAsyncOnly { get; private set; } = false;

	}

}
