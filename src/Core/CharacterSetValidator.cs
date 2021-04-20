using DesiGen.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core
{

	/// <summary>
	/// Character set validation using character set names to look up the appropriate rule
	/// </summary>
	public static class CharacterSetValidator
	{

		/// <summary>
		/// Synchronously test the validity of a string value against the defined character set
		/// </summary>
		/// <param name="valueToTest">The string that is to be tested for validity</param>
		/// <param name="characterSetName">The name of the character set against which to test</param>
		/// <returns>Boolean true if the string is valid based on the defined rule, otherwise false</returns>
		public static bool GetIsValid(string valueToTest, string characterSetName)
		{
			CharacterSetList characterSets;
			string allowedCharacters;
			DisallowedFragmentList disallowedFragmentList;
			IEnumerable<string> disallowedFragments;

			// Retrieve the allowed characters
			characterSets = CharacterSetList.GetCharacterSetList();
			allowedCharacters = characterSets.GetAllowedCharacters(characterSetName);

			// Delegate the testing task for allowed characters
			if (!StringContentValidator.ContainsOnly(valueToTest, allowedCharacters))
			{
				return false;
			}

			// Allowed characters rule passed; now check for the presence of disallowed fragments
			disallowedFragmentList = DisallowedFragmentList.GetDisallowedFragmentList();
			disallowedFragments = disallowedFragmentList.GetDisallowedFragments(characterSetName);
			return StringContentValidator.DoesNotContainAnyOf(valueToTest, disallowedFragments);
		}

		/// <summary>
		/// Asynchronously test the validity of a string value against the defined character set
		/// </summary>
		/// <param name="valueToTest">The string that is to be tested for validity</param>
		/// <param name="characterSetName">The name of the character set against which to test</param>
		/// <returns>Boolean true if the string is valid based on the defined rule, otherwise false</returns>
		public static async Task<bool> GetIsValidAsync(string valueToTest, string characterSetName)
		{
			CharacterSetList characterSets;
			string allowedCharacters;
			DisallowedFragmentList disallowedFragmentList;
			IEnumerable<string> disallowedFragments;

			// Retrieve the allowed characters
			characterSets = await CharacterSetList.GetCharacterSetListAsync();
			allowedCharacters = characterSets.GetAllowedCharacters(characterSetName);

			// Delegate the testing task for allowed characters
			if(!StringContentValidator.ContainsOnly(valueToTest, allowedCharacters))
			{
				return false;
			}

			// Allowed characters rule passed; now check for the presence of disallowed fragments
			disallowedFragmentList = await DisallowedFragmentList.GetDisallowedFragmentListAsync().ConfigureAwait(false);
			disallowedFragments = disallowedFragmentList.GetDisallowedFragments(characterSetName);
			return StringContentValidator.DoesNotContainAnyOf(valueToTest, disallowedFragments);

		}

	}
}
