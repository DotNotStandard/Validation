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

	/// <summary>
	/// Character set validation using character set names to look up the appropriate rule
	/// </summary>
	public class CharacterSetValidator
	{

		private readonly ICharacterSetListCache _characterSetListCache;
		private readonly IDisallowedFragmentListCache _disallowedFragmentListCache;

        #region Constructors

        public CharacterSetValidator(ICharacterSetListCache characterSetListCache, IDisallowedFragmentListCache disallowedFragmentListCache)
        {
			_characterSetListCache = characterSetListCache;
			_disallowedFragmentListCache = disallowedFragmentListCache;
        }

        #endregion

        /// <summary>
        /// Synchronously test the validity of a string value against the defined character set
        /// </summary>
        /// <param name="valueToTest">The string that is to be tested for validity</param>
        /// <param name="characterSetName">The name of the character set against which to test</param>
        /// <returns>Boolean true if the string is valid based on the defined rule, otherwise false</returns>
        public bool GetIsValid(string valueToTest, string characterSetName)
		{
			CharacterSetList characterSets;
			string allowedCharacters;
			DisallowedFragmentList disallowedFragmentList;
			IEnumerable<string> disallowedFragments;

			// Retrieve the allowed characters
			characterSets = _characterSetListCache.GetCharacterSetList();
			allowedCharacters = characterSets.GetAllowedCharacters(characterSetName);

			// Delegate the testing task for allowed characters
			if (!StringContentValidator.ContainsOnly(valueToTest, allowedCharacters))
			{
				return false;
			}

            // Allowed characters rule passed; now check for the presence of disallowed fragments
            disallowedFragmentList = _disallowedFragmentListCache.GetDisallowedFragmentList();
            disallowedFragments = disallowedFragmentList.GetDisallowedFragments(characterSetName);
            return StringContentValidator.DoesNotContainAnyOf(valueToTest, disallowedFragments);
		}

		/// <summary>
		/// Asynchronously test the validity of a string value against the defined character set
		/// </summary>
		/// <param name="valueToTest">The string that is to be tested for validity</param>
		/// <param name="characterSetName">The name of the character set against which to test</param>
		/// <returns>Boolean true if the string is valid based on the defined rule, otherwise false</returns>
		public async Task<bool> GetIsValidAsync(string valueToTest, string characterSetName)
		{
			CharacterSetList characterSets;
			string allowedCharacters;
			DisallowedFragmentList disallowedFragmentList;
			IEnumerable<string> disallowedFragments;

			// Retrieve the allowed characters
			characterSets = await _characterSetListCache.GetCharacterSetListAsync().ConfigureAwait(false);
			allowedCharacters = characterSets.GetAllowedCharacters(characterSetName);

			// Delegate the testing task for allowed characters
			if (!StringContentValidator.ContainsOnly(valueToTest, allowedCharacters))
			{
				return false;
			}

            // Allowed characters rule passed; now check for the presence of disallowed fragments
            disallowedFragmentList = await _disallowedFragmentListCache.GetDisallowedFragmentListAsync().ConfigureAwait(false);
            disallowedFragments = disallowedFragmentList.GetDisallowedFragments(characterSetName);
            return StringContentValidator.DoesNotContainAnyOf(valueToTest, disallowedFragments);

		}

	}
}
