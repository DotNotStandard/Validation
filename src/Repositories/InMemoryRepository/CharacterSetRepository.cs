using DotNotStandard.Validation.Core;
using DotNotStandard.Validation.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Repositories.InMemoryRepository
{
	public class CharacterSetRepository : ICharacterSetRepository
	{

		#region ICharacterSetRepository Implementation

		public IList<CharacterSetDTO> FetchList()
		{
			IList<CharacterSetDTO> characterSets;

			// Create all of the available character sets
			characterSets = new List<CharacterSetDTO>(25);
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 1,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveInteger,
				CharacterSetDescription = "Positive integer numeric values (no decimal places)",
				AllowedCharacters = "0123456789"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 2,
				CharacterSetName = BuiltInRules.CharacterSet.Integer,
				CharacterSetDescription = "Positive and negative integer numeric values (no decimal places)",
				AllowedCharacters = "0123456789-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 3,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveDecimal,
				CharacterSetDescription = "Positive decimal numeric values (including decimal places)",
				AllowedCharacters = "0123456789."
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 4,
				CharacterSetName = BuiltInRules.CharacterSet.Decimal,
				CharacterSetDescription = "Positive and negative decimal numeric values (including decimal places)",
				AllowedCharacters = "0123456789.-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 5,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveGBP,
				CharacterSetDescription = "Positive monetary values (with British currency symbol)",
				AllowedCharacters = "0123456789.£"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 6,
				CharacterSetName = BuiltInRules.CharacterSet.GBP,
				CharacterSetDescription = "Positive and negative monetary values (with British currency symbol)",
				AllowedCharacters = "0123456789.£-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 5,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveUSD,
				CharacterSetDescription = "Positive monetary values (with dollar currency symbol)",
				AllowedCharacters = "0123456789.$"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 6,
				CharacterSetName = BuiltInRules.CharacterSet.USD,
				CharacterSetDescription = "Positive and negative monetary values (with dollar currency symbol)",
				AllowedCharacters = "0123456789.$-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 7,
				CharacterSetName = BuiltInRules.CharacterSet.Alpha,
				CharacterSetDescription = "ASCII characters, including spaces",
				AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 8,
				CharacterSetName = BuiltInRules.CharacterSet.UppercaseAlpha,
				CharacterSetDescription = "Uppercase ASCII characters, including spaces",
				AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ "
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 9,
				CharacterSetName = BuiltInRules.CharacterSet.LowercaseAlpha,
				CharacterSetDescription = "Lowercase ASCII characters, including spaces",
				AllowedCharacters = "abcdefghijklmnopqrstuvwxyz "
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 10,
				CharacterSetName = BuiltInRules.CharacterSet.Alphanumeric,
				CharacterSetDescription = "ASCII characters and decimal numeric symbols, including spaces",
				AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 01234567890.-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 11,
				CharacterSetName = BuiltInRules.CharacterSet.FreeText,
				CharacterSetDescription = "",
				AllowedCharacters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,()_-+=[]?!£%&*:;@#'""\/" + "\t"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 12,
				CharacterSetName = BuiltInRules.CharacterSet.FreeTextMultiLine,
				CharacterSetDescription = "",
				AllowedCharacters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,()_-+=[]?!£%&*:;@#'""\/" + "\t\r\n"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 13,
				CharacterSetName = BuiltInRules.CharacterSet.InCountryTelephone,
				CharacterSetDescription = "0123456789 -",
				AllowedCharacters = ""
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 14,
				CharacterSetName = BuiltInRules.CharacterSet.InternationalTelephone,
				CharacterSetDescription = "0123456789 -()+",
				AllowedCharacters = ""
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 15,
				CharacterSetName = BuiltInRules.CharacterSet.FullFilePath,
				CharacterSetDescription = "The characters allowed in a full directory and file path",
				AllowedCharacters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,()_-+=[]!£%&:;@'\/"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 16,
				CharacterSetName = BuiltInRules.CharacterSet.FileName,
				CharacterSetDescription = "Characters allowed in a file name, with no directory or other path elements",
				AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,()_-+=[]!£%&;@'"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 17,
				CharacterSetName = BuiltInRules.CharacterSet.XMLFragment,
				CharacterSetDescription = "Characters allowed in an XML fragment",
				AllowedCharacters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 .,()_-+=[]?!£%&*:;@#'""\/<>" + "\t"
			});
			//characterSets.Add(new CharacterSetDTO
			//{
			//	CharacterSetId = 18,
			//	CharacterSetName = BuiltInRules.CharacterSet.,
			//	CharacterSetDescription = "",
			//	AllowedCharacters = ""
			//});

			return characterSets;
		}

		public Task<IList<CharacterSetDTO>> FetchListAsync()
		{
			return Task.FromResult(FetchList());
		}

		#endregion

	}
}
