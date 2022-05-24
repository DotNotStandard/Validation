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

	[Serializable]
	internal class CharacterSetList : ICloneable
	{

		private static AutoRefreshingItemCache<CharacterSetList> _cache = new AutoRefreshingItemCache<CharacterSetList>(
			ValidationSubsystem.GetLogger(),
			GetListToCacheAsync,
			new CharacterSetList(),
			TimeSpan.FromMinutes(120));
		private IList<CharacterSetInfo> _list = new List<CharacterSetInfo>();

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

		#endregion

		#region Factory Methods

		private CharacterSetList()
		{
			// Enforce use of factory methods
		}

		public static void Initialise()
        {
			_cache.Initialise();
        }

		public static Task<CharacterSetList> GetCharacterSetListAsync()
		{
			return Task.FromResult(_cache.GetItem());
		}

		public static CharacterSetList GetCharacterSetList()
		{
			return _cache.GetItem();
		}

		#region ICloneable Interface

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

		#region Cache Update Methods

		private static async Task<CharacterSetList> GetListToCacheAsync(CancellationToken cancellationToken)
		{
			ICharacterSetRepository repository;
			CharacterSetList list;

			repository = ValidationSubsystem.GetRequiredService<ICharacterSetRepository>();
			list = new CharacterSetList();
			await list.DataPortal_FetchAsync(repository);
			return list;
		}

		#endregion

		#endregion

		#region Data Access

		private async Task DataPortal_FetchAsync(ICharacterSetRepository repository)
		{
			IList<CharacterSetDTO> items = await repository.FetchListAsync().ConfigureAwait(false);
			await LoadObjectsAsync(items);
		}

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

		private void Add(CharacterSetInfo setInfo)
        {
			_list.Add(setInfo);
        }

        #endregion

    }
}
