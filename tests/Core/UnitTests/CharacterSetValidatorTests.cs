/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core.UnitTests
{

	[TestClass]
	public class CharacterSetValidatorTests
	{
		private static ValidationTestFactory _validationTestFactory;

        [ClassInitialize]
		public static void Initialise(TestContext testContext)
        {
			_validationTestFactory = ValidationTestFactory.InitialiseValidation();
        }

		#region GetIsValid

		[TestMethod]
		public void GetIsValid_NullStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = null;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_EmptyStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = string.Empty;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_1AsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = "1";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_Minus1AsPositiveInteger_ReturnsFalse()
		{

			// Arrange
			string testValue = "-1";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_Minus1AsInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = "-1";
			string characterSetName = BuiltInRules.CharacterSet.SignedInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_DecimalAsPositiveInteger_ReturnsFalse()
		{

			// Arrange
			string testValue = "1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_DecimalAsPositiveDecimal_ReturnsTrue()
		{

			// Arrange
			string testValue = "1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveDecimal;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_NegativeDecimalAsPositiveDecimal_ReturnsFalse()
		{

			// Arrange
			string testValue = "-1.0";
			string characterSetName = BuiltInRules.CharacterSet.PositiveDecimal;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_NegativeDecimalAsDecimal_ReturnsTrue()
		{

			// Arrange
			string testValue = "-1.0";
			string characterSetName = BuiltInRules.CharacterSet.SignedDecimal;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_FullSentenceAsAlphanumeric_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.";
			string characterSetName = BuiltInRules.CharacterSet.LatinAlphanumeric;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_FullSentenceAsFreeText_ReturnsTrue()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeText;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextAsFreeText_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeText;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextAsFreeTextMultiline_ReturnsTrue()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeTextMultiLine;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void GetIsValid_MultiLineTextWithDisallowedStringAsFreeTextMultiline_ReturnsFalse()
		{

			// Arrange
			string testValue = "This is a test of a full sentence, including punctuation.\r\nIt's even made up of multiple lines.\r\n\r\nHow lovely.<script>alert('Hi!')</script>";
			string characterSetName = BuiltInRules.CharacterSet.LatinFreeTextMultiLine;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = validator.GetIsValid(testValue, characterSetName);

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
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = await validator.GetIsValidAsync(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public async Task GetIsValidAsync_EmptyStringAsPositiveInteger_ReturnsTrue()
		{

			// Arrange
			string testValue = string.Empty;
			string characterSetName = BuiltInRules.CharacterSet.PositiveInteger;
			CharacterSetValidator validator = _validationTestFactory.GetCharacterSetValidator();
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = await validator.GetIsValidAsync(testValue, characterSetName);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		#endregion

	}
}
