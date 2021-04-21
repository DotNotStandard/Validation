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
			public const string SignedInteger = "SignedInteger";
			public const string PositiveDecimal = "PositiveDecimal";
			public const string SignedDecimal = "SignedDecimal";
			public const string PositiveGBP = "GBP";
			public const string SignedGBP = "SignedGBP";
			public const string PositiveUSD = "PositiveUSD";
			public const string SignedUSD = "SignedUSD";
			public const string LatinAlpha = "LatinAlpha";
			public const string UppercaseLatinAlpha = "UppercaseLatinAlpha";
			public const string LatinAlphanumeric = "LatinAlphanumeric";
			public const string LatinFreeText = "LatinFreeText";
			public const string LatinFreeTextMultiLine = "LatinFreeTextMultiLine";
			public const string InCountryTelephone = "UKTelephone";
			public const string InternationalTelephone = "Telephone";
			public const string FullFilePath = "FullFilePath";
			public const string FileName = "FileName";
			public const string XMLFragment = "XMLFragment";
		}

	}
}
