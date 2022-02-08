/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Threading.Tasks;
using Csla;
using DotNotStandard.Validation.Core.DataAccess;

// Generated from the built-in Scriban CSLA ReadOnlyChild template

namespace DotNotStandard.Validation.Core
{

	[Serializable]
	internal class DisallowedFragmentInfo : ReadOnlyBase<DisallowedFragmentInfo>
	{

		private static readonly PropertyInfo<int> _disallowedFragmentIdProperty = RegisterProperty<int>(nameof(DisallowedFragmentId));
		private static readonly PropertyInfo<string> _characterSetNameProperty = RegisterProperty<string>(nameof(CharacterSetName));
		private static readonly PropertyInfo<string> _disallowedFragmentProperty = RegisterProperty<string>(nameof(DisallowedFragment));

		#region Exposed Properties and Methods

		public int DisallowedFragmentId
		{
			get { return GetProperty(_disallowedFragmentIdProperty); }
		}

		public string CharacterSetName
		{
			get { return GetProperty(_characterSetNameProperty); }
		}

		public string DisallowedFragment
		{
			get { return GetProperty(_disallowedFragmentProperty); }
		}

		#endregion

		#region Factory Methods

		private DisallowedFragmentInfo()
		{
			// Enforce use of factory methods
		}

		#endregion

		#region Data Access

		[FetchChild]
		private async Task DataPortal_FetchChild(DisallowedFragmentDTO data)
		{
			await LoadObjectAsync(data);
		}

		private Task LoadObjectAsync(DisallowedFragmentDTO data)
		{
			LoadProperty(_disallowedFragmentIdProperty, data.DisallowedFragmentId);
			LoadProperty(_characterSetNameProperty, data.CharacterSetName);
			LoadProperty(_disallowedFragmentProperty, data.DisallowedFragment);
			// Complete the load by requesting children load themselves

			return Task.CompletedTask;
		}

		#endregion

	}
}