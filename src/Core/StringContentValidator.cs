using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core
{

	/// <summary>
	/// Offers validation of the contents of a string against provided character sets
	/// </summary>
	internal static class StringContentValidator
	{

		/// <summary>
		/// Test whether a string contains only characters within the allowed set provided
		/// </summary>
		/// <param name="valueToTest">The string to test for validity</param>
		/// <param name="allowedCharacters">All of the characters that the string is allowed to contain</param>
		/// <returns>Boolean true if the string only contains those characters, false if any others are found</returns>
		internal static bool ContainsOnly(string valueToTest, string allowedCharacters)
		{
			string characterToValidate;

			if (allowedCharacters is null) throw new ArgumentException(nameof(allowedCharacters));

			// Shortcut the check for a null or an empty string
			if (string.IsNullOrEmpty(valueToTest)) return true;

			// Check for the presence of each character in the list of those allowed
			for (int characterPosition = 0; characterPosition < valueToTest.Length; characterPosition++)
			{
				characterToValidate = valueToTest.Substring(characterPosition, 1);
				if (!allowedCharacters.Contains(characterToValidate))
				{
					// There is a character that is not allowed
					return false;
				}
			}

			// If all characters have been identified then the rule is passed
			return true;
		}

		/// <summary>
		/// Test whether a string contains any strings within the disallowed sets provided
		/// </summary>
		/// <param name="valueToTest">The string to test for validity</param>
		/// <param name="disallowedFragments">All of the fragments that the tested string must not contain</param>
		/// <returns>Boolean true if the string contains no disallowed strings, false if any are found</returns>
		internal static bool DoesNotContainAnyOf(string valueToTest, IEnumerable<string> disallowedFragments)
		{
			if (disallowedFragments is null) throw new ArgumentException(nameof(disallowedFragments));

			// Shortcut the check for a null or an empty string
			if (string.IsNullOrEmpty(valueToTest)) return true;

			// Force to uppercase to do case-invariant tests
			valueToTest = valueToTest.ToUpper();

			// Check for the presence of each disallowed string
			foreach (string disallowedFragment in disallowedFragments)
			{
				if (valueToTest.Contains(disallowedFragment.ToUpper()))
				{
					// There is a string that is not allowed
					return false;
				}
			}

			// If no disallowed strings have been identified then the rule is passed
			return true;
		}

	}
}
