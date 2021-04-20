using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DotNotStandard.Validation.Core
{
	public static class BuiltInRules
	{

		public static class CharacterSet
		{
			public const string PositiveInteger = "PositiveInteger";
			public const string Integer = "Integer";
			public const string PositiveDecimal = "PositiveDecimal";
			public const string Decimal = "Decimal";
			public const string PositiveGBP = "PositiveGBP";
			public const string GBP = "GBP";
			public const string PositiveUSD = "PositiveUSD";
			public const string USD = "USD";
			public const string Alpha = "Alpha";
			public const string UppercaseAlpha = "UppercaseAlpha";
			public const string LowercaseAlpha = "LowercaseAlpha";
			public const string Alphanumeric = "Alphanumeric";
			public const string FreeText = "FreeText";
			public const string FreeTextMultiLine = "FreeTextMultiLine";
			public const string InCountryTelephone = "UKTelephone";
			public const string InternationalTelephone = "Telephone";
			public const string DataStructureName = "DataStructureName";
			public const string FieldName = "FieldName";
			public const string FullFilePath = "FullFilePath";
			public const string FileName = "FileName";
			public const string NamingTemplate = "NamingTemplate";
			public const string XMLFragment = "XMLFragment";
			public const string TemplateCode = "TemplateCode";
			public const string ArtefactName = "ArtefactName";
		}

	}
}
