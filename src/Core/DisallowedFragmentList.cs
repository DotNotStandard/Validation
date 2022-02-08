/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	internal class DisallowedFragmentList : ReadOnlyListBase<DisallowedFragmentList, DisallowedFragmentInfo>
	{

		private static DisallowedFragmentList _fallbackList = new DisallowedFragmentList();
		private static InMemoryItemCache<DisallowedFragmentList> _cache = new InMemoryItemCache<DisallowedFragmentList>(
			GetListToCacheAsync,
			GetListToCache,
			TimeSpan.FromMinutes(120));

		#region Exposed Properties and Methods

		/// <summary>
		/// Method to return the disallowed fragments for a character set identified by name
		/// </summary>
		/// <param name="characterSetName">The name of the character set for which the disallowed fragments are required</param>
		/// <returns>An IEnumerable<string> containing the disallowed fragments for the requested rule identified by name</returns>
		public IEnumerable<string> GetDisallowedFragments(string characterSetName)
		{
			IList<string> filteredList = new List<string>();

			if (characterSetName is null) throw new ArgumentNullException(nameof(characterSetName));

			// Iterate all of the children, finding any matching fragments for the requested rule by name
			foreach (DisallowedFragmentInfo fragmentInfo in this)
			{
				// Add any child that applies to all scenarios, or this specific scenario
				if (string.IsNullOrWhiteSpace(fragmentInfo.CharacterSetName) || 
					fragmentInfo.CharacterSetName.Equals(characterSetName, StringComparison.InvariantCultureIgnoreCase))
				{ 
					// We've found an appropriate fragment for this scenario, so add it to the set
					filteredList.Add(fragmentInfo.DisallowedFragment);
				}
			}

			// Return all of the disallowed fragments applicable
			return filteredList;
		}

		#endregion

		#region Factory Methods

		private DisallowedFragmentList()
		{
			// Enforce use of factory methods
		}

		public static async Task<DisallowedFragmentList> GetDisallowedFragmentListAsync()
		{
			return await _cache.GetItemAsync().ConfigureAwait(false);
		}

		public static DisallowedFragmentList GetDisallowedFragmentList()
		{
			return _cache.GetItem();
		}

		private static async Task<DisallowedFragmentList> GetListToCacheAsync()
		{
			DisallowedFragmentList list;

			list = await DataPortal.FetchAsync<DisallowedFragmentList>(true);
			_fallbackList = list;
			return list;
		}

		public static DisallowedFragmentList GetListToCache()
		{
			if (DataPortalConfig.IsAsyncOnly)
			{
				return _fallbackList;
			}
			else
			{ 
				return DataPortal.Fetch<DisallowedFragmentList>();
			}
		}

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
		private void DataPortal_Fetch([Inject] IDisallowedFragmentRepository repository)
		{
			IList<DisallowedFragmentDTO> items = repository.FetchList();
			LoadObjects(items);
		}

		[Fetch]
		private async Task DataPortal_FetchAsync(bool differentiator, [Inject] IDisallowedFragmentRepository repository)
		{
			IList<DisallowedFragmentDTO> items = await repository.FetchListAsync().ConfigureAwait(false);
			await LoadObjectsAsync(items);
		}

		private void LoadObjects(IList<DisallowedFragmentDTO> items)
		{
			bool raiseEvents;

			raiseEvents = RaiseListChangedEvents;
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			foreach (var item in items)
			{
				Add(DataPortal.FetchChild<DisallowedFragmentInfo>(item));
			}

			IsReadOnly = true;
			RaiseListChangedEvents = raiseEvents;
		}

		private async Task LoadObjectsAsync(IList<DisallowedFragmentDTO> items)
		{
			bool raiseEvents;

			raiseEvents = RaiseListChangedEvents;
			RaiseListChangedEvents = false;
			IsReadOnly = false;

			foreach (var item in items)
			{
				Add(await DataPortal.FetchChildAsync<DisallowedFragmentInfo>(item).ConfigureAwait(false));
			}

			IsReadOnly = true;
			RaiseListChangedEvents = raiseEvents;
		}

		#endregion

	}
}
