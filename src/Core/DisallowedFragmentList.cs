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
using DotNotStandard.Caching.Core.InMemory;
using DotNotStandard.Validation.Core.DataAccess;

// Generated from the built-in Scriban CSLA ReadOnlyRootList template

namespace DotNotStandard.Validation.Core
{

	[Serializable]
	public class DisallowedFragmentList : ICloneable
	{

		private IList<DisallowedFragmentInfo> _list = new List<DisallowedFragmentInfo>();

		#region Constructors

		internal DisallowedFragmentList()
		{
			// Restrict access to create instances of the type
		}

		#endregion

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
			foreach (DisallowedFragmentInfo fragmentInfo in _list)
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

        #region ICloneable Interface

		/// <summary>
		/// Create a complete, deep clone the list.
		/// Used by the underlying cache to avoid threading issues.
		/// </summary>
		/// <returns>A completely new instance of the list</returns>
        public object Clone()
		{
			DisallowedFragmentList list = new DisallowedFragmentList();
			foreach (DisallowedFragmentInfo fragmentInfo in _list)
            {
				list.Add((DisallowedFragmentInfo)fragmentInfo.Clone());
            }

			return list;
		}

        #endregion

        #endregion

		#region Data Access

		/// <summary>
		/// Load the internal list from the underlying data source
		/// </summary>
		/// <param name="repository">The repository from which to load the data</param>
		internal async Task LoadListAsync(IDisallowedFragmentRepository repository)
		{
			IList<DisallowedFragmentDTO> items = await repository.FetchListAsync().ConfigureAwait(false);
			await LoadObjectsAsync(items);
		}

		/// <summary>
		/// Helper method for loading of the list from the data source
		/// </summary>
		/// <param name="items">The list of items returned by the data source</param>
		private Task LoadObjectsAsync(IList<DisallowedFragmentDTO> items)
		{
			DisallowedFragmentInfo info;

			foreach (var item in items)
			{
				info = new DisallowedFragmentInfo(item);
				_list.Add(info);
			}

			return Task.CompletedTask;
		}

		#endregion

		#region Private Helper Methods

		/// <summary>
		/// Support addition of new items to the underlying list for use in cloning
		/// </summary>
		/// <param name="fragmentInfo">The disallowed fragment info to be added to the list</param>
		private void Add(DisallowedFragmentInfo fragmentInfo)
        {
			_list.Add(fragmentInfo);
        }

        #endregion

    }
}
