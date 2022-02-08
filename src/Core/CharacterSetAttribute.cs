/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNotStandard.Validation.Core
{

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class CharacterSetAttribute : ValidationAttribute
	{

		private readonly string _characterSetName;

		#region Constructors

		public CharacterSetAttribute(string characterSetName)
		{
			_characterSetName = characterSetName;
		}

		#endregion

		#region Method Overrides

		public override bool IsValid(object value)
		{
			bool result;

			if (value is null) return true;

			// Delegate the test to the validator class and return the result
			result = CharacterSetValidator.GetIsValid(value.ToString(), _characterSetName);

			return result;
		}

		#endregion

	}
}
