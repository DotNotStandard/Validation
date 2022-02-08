/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
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

		private const string _basicLatinUppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string _basicLatinLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		private const string _latin1SupplementUppercaseLetters = "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞ";
		private const string _latin1SupplementLetters = "ªµºÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿ";
		private const string _latinExtendedAUppercaseLetters = "ĀĂĄĆĈĊČĎĐĒĔĖĘĚĜĞĠĢĤĦĨĪĬĮİĲĴĶĹĻĽĿŁŃŅŇŊŌŎŐŒŔŖŘŚŜŞŠŢŤŦŨŪŬŮŰŲŴŶŸŹŻŽ";
		private const string _latinExtendedALetters = "ĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁłŃńŅņŇňŉŊŋŌōŎŏŐőŒœŔŕŖŗŘřŚśŜŝŞşŠšŢţŤťŦŧŨũŪūŬŭŮůŰűŲųŴŵŶŷŸŹźŻżŽžſ";
		private const string _latinExtendedBUppercaseLetters = "ƁƂƄƆƇƉƊƋƎƏƐƑƓƔƖƗƘƜƝƟƠƢƤƦƧƩƬƮƯƱƲƳƵƷƸƼǄǇǊǍǏǑǓǕǗǙǛǞǠǢǤǦǨǪǬǮǱǴǶǷǸǺǼǾȀȂȄȆȈȊȌȎȐȒȔȖȘȚȜȞȠȢȤȦȨȪȬȮȰȲȺȻȽȾɁɃɄɅɆɈɊɌɎ";
		private const string _latinExtendedBLetters = "ƀƁƂƃƄƅƆƇƈƉƊƋƌƍƎƏƐƑƒƓƔƕƖƗƘƙƚƛƜƝƞƟƠơƢƣƤƥƦƧƨƩƪƫƬƭƮƯưƱƲƳƴƵƶƷƸƹƺƻƼƽƾƿǀǁǂǃǄǅǆǇǈǉǊǋǌǍǎǏǐǑǒǓǔǕǖǗǘǙǚǛǜǝǞǟǠǡǢǣǤǥǦǧǨǩǪǫǬǭǮǯǰǱǲǳǴǵǶǷǸǹǺǻǼǽǾǿȀȁȂȃȄȅȆȇȈȉȊȋȌȍȎȏȐȑȒȓȔȕȖȗȘșȚțȜȝȞȟȠȡȢȣȤȥȦȧȨȩȪȫȬȭȮȯȰȱȲȳȴȵȶȷȸȹȺȻȼȽȾȿɀɁɂɃɄɅɆɇɈɉɊɋɌɍɎɏ";
		private const string _latinExtendedAdditionalUppercaseLetters = "ḀḂḄḆḈḊḌḎḐḒḔḖḘḚḜḞḠḢḤḦḨḪḬḮḰḲḴḶḸḺḼḾṀṂṄṆṈṊṌṎṐṒṔṖṘṚṜṞṠṢṤṦṨṪṬṮṰṲṴṶṸṺṼṾẀẂẄẆẈẊẌẎẐẒẔẞẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼẾỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪỬỮỰỲỴỶỸỺỼỾ";
		private const string _latinExtendedAdditionalLetters = "ḀḁḂḃḄḅḆḇḈḉḊḋḌḍḎḏḐḑḒḓḔḕḖḗḘḙḚḛḜḝḞḟḠḡḢḣḤḥḦḧḨḩḪḫḬḭḮḯḰḱḲḳḴḵḶḷḸḹḺḻḼḽḾḿṀṁṂṃṄṅṆṇṈṉṊṋṌṍṎṏṐṑṒṓṔṕṖṗṘṙṚṛṜṝṞṟṠṡṢṣṤṥṦṧṨṩṪṫṬṭṮṯṰṱṲṳṴṵṶṷṸṹṺṻṼṽṾṿẀẁẂẃẄẅẆẇẈẉẊẋẌẍẎẏẐẑẒẓẔẕẖẗẘẙẚẛẜẝẞẟẠạẢảẤấẦầẨẩẪẫẬậẮắẰằẲẳẴẵẶặẸẹẺẻẼẽẾếỀềỂểỄễỆệỈỉỊịỌọỎỏỐốỒồỔổỖỗỘộỚớỜờỞởỠỡỢợỤụỦủỨứỪừỬửỮữỰựỲỳỴỵỶỷỸỹỺỻỼỽỾỿ";
		private const string _latinExtendedCLetters = "ⱠⱡⱢⱣⱤⱥⱦⱧⱨⱩⱪⱫⱬⱭⱮⱯⱰⱱⱲⱳⱴⱵⱶⱷⱸⱹⱺⱻⱼⱽⱾⱿ";
		private const string _latinExtendedDLetters = "ꜢꜣꜤꜥꜦꜧꜨꜩꜪꜫꜬꜭꜮꜯꜰꜱꜲꜳꜴꜵꜶꜷꜸꜹꜺꜻꜼꜽꜾꜿꝀꝁꝂꝃꝄꝅꝆꝇꝈꝉꝊꝋꝌꝍꝎꝏꝐꝑꝒꝓꝔꝕꝖꝗꝘꝙꝚꝛꝜꝝꝞꝟꝠꝡꝢꝣꝤꝥꝦꝧꝨꝩꝪꝫꝬꝭꝮꝯꝰꝱꝲꝳꝴꝵꝶꝷꝸꝹꝺꝻꝼꝽꝾꝿꞀꞁꞂꞃꞄꞅꞆꞇꞈꞋꞌꞍꞎꞏꞐꞑꞒꞓꞔꞕꞖꞗꞘꞙꞚꞛꞜꞝꞞꞟꞠꞡꞢꞣꞤꞥꞦꞧꞨꞩꞪꞫꞬꞭꞮꞯꞰꞱꞲꞳꞴꞵꞶꞷꞸꞹꟷꟸꟹꟺꟻꟼꟽꟾꟿ";
		private const string _latinExtendedELetters = "ꬰꬱꬲꬳꬴꬵꬶꬷꬸꬹꬺꬻꬼꬽꬾꬿꭀꭁꭂꭃꭄꭅꭆꭇꭈꭉꭊꭋꭌꭍꭎꭏꭐꭑꭒꭓꭔꭕꭖꭗꭘꭙꭚꭜꭝꭞꭟꭠꭡꭢꭣꭤꭥ";
		private const string _latinLetters = _basicLatinLetters + _latin1SupplementLetters + _latinExtendedALetters + _latinExtendedBLetters + 
			_latinExtendedAdditionalLetters + _latinExtendedCLetters + _latinExtendedDLetters + _latinExtendedELetters;
		private const string _latinCommonLetters = _basicLatinLetters + _latin1SupplementLetters + _latinExtendedALetters + _latinExtendedBLetters + _latinExtendedAdditionalLetters;
		private const string _latinCommonUppercaseLetters = _basicLatinUppercaseLetters + _latin1SupplementUppercaseLetters + 
			_latinExtendedAUppercaseLetters + _latinExtendedBUppercaseLetters + _latinExtendedAdditionalUppercaseLetters;
		private const string _arabicNumerals = "0123456789";

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
				AllowedCharacters = _arabicNumerals
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 2,
				CharacterSetName = BuiltInRules.CharacterSet.SignedInteger,
				CharacterSetDescription = "Positive and negative integer numeric values (no decimal places)",
				AllowedCharacters = _arabicNumerals + "-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 3,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveDecimal,
				CharacterSetDescription = "Positive decimal numeric values (including decimal places)",
				AllowedCharacters = _arabicNumerals + "."
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 4,
				CharacterSetName = BuiltInRules.CharacterSet.SignedDecimal,
				CharacterSetDescription = "Positive and negative decimal numeric values (including decimal places)",
				AllowedCharacters = _arabicNumerals + ".-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 5,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveGBP,
				CharacterSetDescription = "Positive monetary values (with British currency symbol)",
				AllowedCharacters = _arabicNumerals + ".£"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 6,
				CharacterSetName = BuiltInRules.CharacterSet.SignedGBP,
				CharacterSetDescription = "Positive and negative monetary values (with British currency symbol)",
				AllowedCharacters = _arabicNumerals + ".£-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 5,
				CharacterSetName = BuiltInRules.CharacterSet.PositiveUSD,
				CharacterSetDescription = "Positive monetary values (with dollar currency symbol)",
				AllowedCharacters = _arabicNumerals + ".$"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 6,
				CharacterSetName = BuiltInRules.CharacterSet.SignedUSD,
				CharacterSetDescription = "Positive and negative monetary values (with dollar currency symbol)",
				AllowedCharacters = _arabicNumerals + ".$-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 7,
				CharacterSetName = BuiltInRules.CharacterSet.LatinAlpha,
				CharacterSetDescription = "Latin characters, including spaces",
				AllowedCharacters = _latinCommonLetters + " "
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 8,
				CharacterSetName = BuiltInRules.CharacterSet.UppercaseLatinAlpha,
				CharacterSetDescription = "Uppercase Latin characters, including spaces",
				AllowedCharacters = _latinCommonUppercaseLetters + " "
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 10,
				CharacterSetName = BuiltInRules.CharacterSet.LatinAlphanumeric,
				CharacterSetDescription = "Latin characters and decimal numeric symbols, including spaces",
				AllowedCharacters = _latinCommonLetters + _arabicNumerals + " .-"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 11,
				CharacterSetName = BuiltInRules.CharacterSet.LatinFreeText,
				CharacterSetDescription = "Latin free text, excluding risky characters",
				AllowedCharacters = _latinCommonLetters + _arabicNumerals + @" .,()_-+=[]?!£%&*:;@#'""\/" + "\t"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 12,
				CharacterSetName = BuiltInRules.CharacterSet.LatinFreeTextMultiLine,
				CharacterSetDescription = "Latin free text including line breaks, excluding risky characters",
				AllowedCharacters = _latinCommonLetters + _arabicNumerals + @" .,()_-+=[]?!£%&*:;@#'""\/" + "\t\r\n"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 13,
				CharacterSetName = BuiltInRules.CharacterSet.InCountryTelephone,
				CharacterSetDescription = "Telephone numbers without international dialling",
				AllowedCharacters = _arabicNumerals + " -"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 14,
				CharacterSetName = BuiltInRules.CharacterSet.InternationalTelephone,
				CharacterSetDescription = "Telephone numbers including international dialling",
				AllowedCharacters = _arabicNumerals + " -()+"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 15,
				CharacterSetName = BuiltInRules.CharacterSet.FullFilePath,
				CharacterSetDescription = "The characters allowed in a full directory and file path",
				AllowedCharacters = _basicLatinLetters + _latin1SupplementLetters + _arabicNumerals + @" .,()_-+=[]!£%&:;@'\/"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 16,
				CharacterSetName = BuiltInRules.CharacterSet.FileName,
				CharacterSetDescription = "Characters allowed in a file name, with no directory or other path elements",
				AllowedCharacters = _basicLatinLetters + _latin1SupplementLetters + _arabicNumerals + " .,()_-+=[]!£%&;@'"
			});
			characterSets.Add(new CharacterSetDTO
			{
				CharacterSetId = 17,
				CharacterSetName = BuiltInRules.CharacterSet.XMLFragment,
				CharacterSetDescription = "Characters allowed in an XML fragment",
				AllowedCharacters = _basicLatinLetters + _arabicNumerals + @" .,()_-+=[]?!£%&*:;@#'""\/<>" + "\t"
			});

			return characterSets;
		}

		public Task<IList<CharacterSetDTO>> FetchListAsync()
		{
			return Task.FromResult(FetchList());
		}

		#endregion

	}
}
