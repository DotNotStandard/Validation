using System;
using System.Threading.Tasks;
using Csla;
using DotNotStandard.Validation.Core.DataAccess;

// Generated from the built-in Scriban CSLA ReadOnlyChild template

namespace DesiGen.Core
{

	[Serializable]
	internal class CharacterSetInfo : ReadOnlyBase<CharacterSetInfo>
	{

		private static readonly PropertyInfo<int> _characterSetIdProperty = RegisterProperty<int>(nameof(CharacterSetId));
		private static readonly PropertyInfo<string> _characterSetNameProperty = RegisterProperty<string>(nameof(CharacterSetName));
		private static readonly PropertyInfo<string> _allowedCharactersProperty = RegisterProperty<string>(nameof(AllowedCharacters));

		#region Exposed Properties and Methods

		public int CharacterSetId
		{
			get { return GetProperty(_characterSetIdProperty); }
		}

		public string CharacterSetName
		{
			get { return GetProperty(_characterSetNameProperty); }
		}

		public string AllowedCharacters
		{
			get { return GetProperty(_allowedCharactersProperty); }
		}

		#endregion

		#region Factory Methods

		private CharacterSetInfo()
		{
			// Enforce use of factory methods
		}

		#endregion

		#region Data Access

		[FetchChild]
		private async Task DataPortal_FetchChild(CharacterSetDTO data)
		{
			await LoadObjectAsync(data);
		}

		private Task LoadObjectAsync(CharacterSetDTO data)
		{
			LoadProperty(_characterSetIdProperty, data.CharacterSetId);
			LoadProperty(_characterSetNameProperty, data.CharacterSetName);
			LoadProperty(_allowedCharactersProperty, data.AllowedCharacters);
			// Complete the load by requesting children load themselves

			return Task.CompletedTask;
		}

		#endregion

	}
}