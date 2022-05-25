/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNotStandard.Caching.Core.InMemory;
using DotNotStandard.Validation.Core.DataAccess;

namespace DotNotStandard.Validation.Core
{

	/// <summary>
	/// The list of character sets supported by the subsystem
	/// </summary>
	[Serializable]
	public class CharacterSetList : ICloneable
	{

		private IList<CharacterSetInfo> _list = new List<CharacterSetInfo>();

		#region Constructors

		internal CharacterSetList()
		{
			// Restrict access to construction of this type
		}

        #endregion

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
			foreach (CharacterSetInfo characterSet in _list)
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

		#region ICloneable Interface

		/// <summary>
		/// Create a complete, disconnected clone of the list.
		/// Used by the underlying cache to avoid threading issues
		/// </summary>
		/// <returns>A complete, deep clone of the list</returns>
		public object Clone()
		{
			CharacterSetList list = new CharacterSetList();
			foreach (CharacterSetInfo setInfo in _list)
			{
				list.Add((CharacterSetInfo)setInfo.Clone());
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
		internal async Task LoadListAsync(ICharacterSetRepository repository)
		{
			IList<CharacterSetDTO> items = await repository.FetchListAsync().ConfigureAwait(false);
			await LoadObjectsAsync(items);
		}

		/// <summary>
		/// Helper method for loading of the list from the data source
		/// </summary>
		/// <param name="items">The list of items returned by the data source</param>
		private Task LoadObjectsAsync(IList<CharacterSetDTO> items)
		{
			CharacterSetInfo info;

			foreach (var item in items)
			{
				info = new CharacterSetInfo(item);
				_list.Add(info);
			}

			return Task.CompletedTask;
		}

        #endregion

        #region Private Helper Methods

		/// <summary>
		/// Support addition of new items to the underlying list for use in cloning
		/// </summary>
		/// <param name="setInfo">The character set info to be added to the list</param>
		private void Add(CharacterSetInfo setInfo)
        {
			_list.Add(setInfo);
        }

        #endregion

    }
}
