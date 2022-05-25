/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core.UnitTests
{

	[TestClass]
	public class StringContentValidatorTests
	{
		private static ValidationTestFactory _validationTestFactory;

		[ClassInitialize]
		public static void Initialise(TestContext testContext)
		{
			_validationTestFactory = ValidationTestFactory.InitialiseValidation();
		}

		#region ContainsOnly

		[TestMethod]
		public void ContainsOnly_NullTestString_ReturnsTrue()
		{
			// Arrange
			string testValue = null;
			string allowedCharacters = string.Empty;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_EmptyTestString_ReturnsTrue()
		{
			// Arrange
			string testValue = string.Empty;
			string allowedCharacters = string.Empty;
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_AAAWhenOnlyBAllowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "AAA";
			string allowedCharacters = "B";
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_AAAWhenOnlyLowercaseAAllowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "AAA";
			string allowedCharacters = "a";
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_AAAWhenOnlyUppercaseAAllowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "AAA";
			string allowedCharacters = "A";
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_AAAWhenAllAlphaAndSpaceAllowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "AAA";
			string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ";
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_ParagraphWhenAllAlphaSpaceAndPunctuationAllowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "This is a full sentence that should be valid.\tIt even contains a tab.";
			string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz .,\t\r\n";
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void ContainsOnly_MultilineWhenAllAlphaSpaceAndPunctuationAllowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "This is a full paragraph that should be valid.\tIt even contains a tab.\r\nNot to mention it's multi-line!";
			string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz .,!?'-()\t\r\n";
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.ContainsOnly(testValue, allowedCharacters);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		#endregion

		#region DoesNotContainAnyOf

		[TestMethod]
		public void DoesNotContainAnyOf_NullTestString_ReturnsTrue()
		{
			// Arrange
			string testValue = null;
			string[] disallowedFragments = new string[] { };
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_EmptyTestString_ReturnsTrue()
		{
			// Arrange
			string testValue = string.Empty;
			string[] disallowedFragments = new string[] { };
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_AAAWhenBDisallowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "AAA";
			string[] disallowedFragments = new string[] { "B" };
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_AAAWhenADisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "AAA";
			string[] disallowedFragments = new string[] { "A" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_AAAWhenAandCDisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "AAA";
			string[] disallowedFragments = new string[] { "A", "C" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_ABCWhenCandDDisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "ABC";
			string[] disallowedFragments = new string[] { "C", "D" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_ABCWhenCDandEFDisallowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "ABC";
			string[] disallowedFragments = new string[] { "CD", "EF" };
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_ABCWhenBCandDEDisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "ABC";
			string[] disallowedFragments = new string[] { "BC", "DE" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_ABCWhenLowercaseBCandDEDisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "ABC";
			string[] disallowedFragments = new string[] { "bc", "de" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_LowercaseABCWhenLowercaseCandDDisallowed_ReturnsFalse()
		{
			// Arrange
			string testValue = "abc";
			string[] disallowedFragments = new string[] { "c", "d" };
			bool actualResult;
			bool expectedResult = false;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		[TestMethod]
		public void DoesNotContainAnyOf_LowercaseABCWhenLowercaseDEFDisallowed_ReturnsTrue()
		{
			// Arrange
			string testValue = "abc";
			string[] disallowedFragments = new string[] { "d", "e", "f" };
			bool actualResult;
			bool expectedResult = true;

			// Act
			actualResult = StringContentValidator.DoesNotContainAnyOf(testValue, disallowedFragments);

			// Assert
			Assert.AreEqual(expectedResult, actualResult);

		}

		#endregion

	}
}
