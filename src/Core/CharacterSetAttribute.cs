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

	/// <summary>
	/// DataAnnotations attribute used to apply character set requirements to string values
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public sealed class CharacterSetAttribute : ValidationAttribute
	{

		private readonly string _characterSetName;

		#region Constructors

		public CharacterSetAttribute(string characterSetName) : base("{0} contains invalid characters")
		{
			_characterSetName = characterSetName;
		}

        #endregion

        #region Base Overrides

        public override bool RequiresValidationContext => true;

		/// <summary>
		/// Apply the validation rule defined in the attribute
		/// </summary>
		/// <param name="value">The value to be validated</param>
		/// <param name="validationContext">The validation context within which we are operating</param>
		/// <returns>ValidationResult indicating the outcome of the operation</returns>
		/// <exception cref="ArgumentNullException">ValidationContext parameter has not been provided</exception>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			CharacterSetValidator validator;
			string message;

			if (validationContext is null) throw new ArgumentNullException(nameof(validationContext));
			if (value is null) return ValidationResult.Success;

			// Delegate the test to the validator class and return the result
			validator = (CharacterSetValidator)validationContext.GetService(typeof(CharacterSetValidator));
			if (validator.GetIsValid(value.ToString(), _characterSetName))
            {
				return ValidationResult.Success;
            }

			message = FormatErrorMessage(validationContext.DisplayName);
			return new ValidationResult(message);
		}

		#endregion

	}
}
