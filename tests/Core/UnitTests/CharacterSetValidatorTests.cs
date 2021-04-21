using DotNotStandard.Validation.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.UnitTests
{

	[TestClass]
	public class CharacterSetValidatorTests
	{

		#region GetIsValid

		[TestMethod]
		public void GetIsValid_NullStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = null;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_EmptyStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = string.Empty;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_1AsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = "1";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_Minus1AsPositiveInteger_ReturnsFalse()
		{

			// Arrange
			string testValue = "-1";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_Minus1AsInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = "-1";
			string characterSetName = BuiltInRules.CharacterSet.SignedInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_DecimalAsPositiveInteger_ReturnsFalse()
		{

			// Arrange
			string testValue = "1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_DecimalAsPositiveDecimal_ReturnsTrue()
		{

			// Arrange
			string testValue = "1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveDecimal;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_NegativeDecimalAsPositiveDecimal_ReturnsFalse()
		{

			// Arrange
			string testValue = "-1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveDecimal;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_NegativeDecimalAsDecimal_ReturnsTrue()
		{

			// Arrange
			string testValue = "-1.0";
			string characterSetName = BuiltInRules.CharacterSet.SignedDecimal;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_FullSentenceAsAlphanumeric_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.";
			string characterSetName = BuiltInRules.CharacterSet.LatinAlphanumeric;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_FullSentenceAsFreeText_ReturnsTrue()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeText;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextAsFreeText_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeText;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextAsFreeTextMultiline_ReturnsTrue()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeTextMultiLine;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextWithDisallowedStringAsFreeTextMultiline_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.<script>alert('Hi!')</script>";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeTextMultiLine;
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = CharacterSetValidator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		#endregion

		#region GetIsValidAsync

		[TestMethod]
		public async Task GetIsValidAsync_NullStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = null;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = await CharacterSetValidator.GetIsValidAsync(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public async Task GetIsValidAsync_EmptyStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = string.Empty;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = await CharacterSetValidator.GetIsValidAsync(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		#endregion

	}
}
