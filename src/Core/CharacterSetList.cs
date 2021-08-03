using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Csla;
using DotNotStandard.Caching.Core.InMemory;
using DotNotStandard.Validation.Core.DataAccess;

// Generated from the built-in Scriban CSLA ReadOnlyRootList template

namespace DotNotStandard.Validation.Core
{

	[Serializable]
	internal class CharacterSetList : ReadOnlyListBase<CharacterSetList, CharacterSetInfo>
	{

		private static CharacterSetList _fallbackList = new CharacterSetList();
		private static InMemoryItemCache<CharacterSetList> _cache = new InMemoryItemCache<CharacterSetList>(
			GetListToCacheAsync,
			GetListToCache,
			TimeSpan.FromMinutes(120));

		#region Exposed Properties and Methods

		/// <summary>
		/// Method to return the allowed characters for a character set identified by name
		/// </summary>
		/// <param name="characterSetName">The name of the character set for which the allowed characters are required</param>
		/// <returns>A string containing the allowed characters for the requested rule identified by name</returns>
		/// <remarks>Throws an ArgumentOutOfRangeException if the name is not recognised</remarks>
		public string GetAllowedCharacters(string characterSetName)
		{
			if (characterSetName is null) throw new ArgumentNullException(nameof(characterSetName));

			// Iterate all of the children, finding the matching character set by name
			foreach (CharacterSetInfo characterSet in this)
			{
				if (characterSet.CharacterSetName.Equals(characterSetName, StringComparison.InvariantCultureIgnoreCase))
				{ 
					// We've found the appropriate character set, so return its allowed characters
					return characterSet.AllowedCharacters;
				}
			}

			// If we've not yet returned the character set then it wasn't found!
			throw new ArgumentOutOfRangeException($"Requested character set {characterSetName} is not defined!");
		}

		#endregion

		#region Factory Methods

		private CharacterSetList()
		{
			// Enforce use of factory methods
		}

		public static async Task<CharacterSetList> GetCharacterSetListAsync()
		{
			return await _cache.GetItemAsync().ConfigureAwait(false);
		}

		public static CharacterSetList GetCharacterSetList()
		{
			return _cache.GetItem();
		}

		#region Cache Update Methods

		private static async Task<CharacterSetList> GetListToCacheAsync()
		{
			CharacterSetList list;

			list = await DataPortal.FetchAsync<CharacterSetList>(true);
			_fallbackList = list;
			return list;
		}

		private static CharacterSetList GetListToCache()
		{
			if (DataPortalConfig.IsAsyncOnly)
			{
				return _fallbackList;
			}
			else
			{
				return DataPortal.Fetch<CharacterSetList>();
			}
		}

		#endregion

		#endregion

		#region Authorisation 

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void AddObjectAuthorizationRules()
		{
			// Not authorisation rules required; this is available to all users
		}

		#endregion

		#region Data Access

		#region Criteria

		//[Serializable]
		//private class Criteria : CriteriaBase<Criteria>
		//{
		//
		//	private static readonly PropertyInfo<int> _parentIdProperty = RegisterProperty<int>(nameof(ParentId));
		//
		//	public Criteria(int parentId)
		//	{
		//		ParentId = parentId;
		//	}
		//
		//	public int ParentId
		//	{
		//		get { return ReadProperty(_parentIdProperty); }
		//		private set { LoadProperty(_parentIdProperty, value); }
		//	}
		//}

		#endregion

		[Fetch]
		private void DataPortal_Fetch([Inject] ICharacterSetRepository repository)
		{
			IList<CharacterSetDTO> items = repository.FetchList();
			LoadObjects(items);
		}

		[Fetch]
		private async Task DataPortal_FetchAsync(bool differentiator, [Inject] ICharacterSetRepository repository)
		{
			IList<CharacterSetDTO> items = await repository.FetchListAsync().ConfigureAwait(false);
			await LoadObjectsAsync(items);
		}

		private void LoadObjects(IList<CharacterSetDTO> items)
		{
			bool raiseEvents;

			raiseEvents = RaiseListChangedEvents;
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			foreach (var item in items)
			{
				Add(DataPortal.FetchChild<CharacterSetInfo>(item));
			}

			IsReadOnly = true;
			RaiseListChangedEvents = raiseEvents;
		}

		private async Task LoadObjectsAsync(IList<CharacterSetDTO> items)
		{
			bool raiseEvents;

			raiseEvents = RaiseListChangedEvents;
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			foreach (var item in items)
			{
				Add(await DataPortal.FetchChildAsync<CharacterSetInfo>(item).ConfigureAwait(false));
			}

			IsReadOnly = true;
			RaiseListChangedEvents = raiseEvents;
		}

		#endregion

	}
}
