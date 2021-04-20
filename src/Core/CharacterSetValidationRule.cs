using Csla.Core;
using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core
{
	public class CharacterSetValidationRule : BusinessRuleAsync
	{
		private readonly string _allowedCharacterSetName;

		public CharacterSetValidationRule(IPropertyInfo primaryProperty, string allowedCharacterSetName)
			: base(primaryProperty)
		{
			InputProperties = new List<Csla.Core.IPropertyInfo> { primaryProperty };
			_allowedCharacterSetName = allowedCharacterSetName;
		}

		protected override async Task ExecuteAsync(IRuleContext context)
		{
			string value;

			// Get the value of the property we are validating and check it has a value
			value = ReadProperty(context.InputPropertyValues, PrimaryProperty)?.ToString();
			if (value is null)
			{
				// An object that has no value does not fail this rule
				context.AddSuccessResult(false);
				return;
			}

			// Peform the validation test on the value we have been provided
			if (!await CharacterSetValidator.GetIsValidAsync(value, _allowedCharacterSetName))
			{
				context.AddErrorResult($"{PrimaryProperty.FriendlyName} contains invalid characters!");
			}

			// If all rules have been met then the property is valid
			context.AddSuccessResult(false);
		}

	}
}
