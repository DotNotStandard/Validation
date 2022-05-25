using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core.UnitTests
{
    [TestClass]
    public class CharacterSetAttributeTests
    {
        private static ValidationTestFactory _validationTestFactory;

        [ClassInitialize]
        public static void Initialise(TestContext testContext)
        {
            _validationTestFactory = ValidationTestFactory.InitialiseValidation();
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Validate_LatinAlphaCharactersetOnStringContainingNonAlpha_ThrowsValidationException()
        {
            // Arrange
            string testValue = "123";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.LatinAlpha);

            // Act
            attribute.Validate(testValue, validationContext);

            // Assert
        }

        [TestMethod]
        public void Validate_LatinAlphaCharactersetOnStringContainingOnlyAlpha_ReturnsValidationSuccess()
        {
            // Arrange
            string testValue = "ABC";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.LatinAlpha);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_LatinAlphaCharactersetOnStringContainingNonAlpha_DoesNotReturnValidationSuccess()
        {
            // Arrange
            string testValue = "123";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.LatinAlpha);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_PositiveIntegerCharactersetOnStringContainingPositiveInteger_ReturnsValidationSuccess()
        {
            // Arrange
            string testValue = "123";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.PositiveInteger);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_PositiveIntegerCharactersetOnStringContainingNegativeInteger_DoesNotReturnValidationSuccess()
        {
            // Arrange
            string testValue = "-123";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.PositiveInteger);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_PositiveIntegerCharactersetOnStringContainingDecimal_DoesNotReturnValidationSuccess()
        {
            // Arrange
            string testValue = "123.45";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.PositiveInteger);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Validate_PositiveDecimalCharactersetOnStringContainingDecimal_ReturnsValidationSuccess()
        {
            // Arrange
            string testValue = "123.45";
            ValidationContext validationContext = CreateValidationContext(testValue);
            CharacterSetAttribute attribute = new CharacterSetAttribute(BuiltInRules.CharacterSet.PositiveDecimal);
            ValidationResult expected = ValidationResult.Success;
            ValidationResult actual;

            // Act
            actual = attribute.GetValidationResult(testValue, validationContext);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithValidLatinAlpha_ReturnsTrue()
        {
            // Arrange
            TestObject testValue = new TestObject() { LatinAlpha="ABC" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            bool expected = true;
            bool actual;

            // Act
            actual = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithInvalidLatinAlphaValue_ReturnsFalse()
        {
            // Arrange
            TestObject testValue = new TestObject() { LatinAlpha = "123" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            bool expected = false;
            bool actual;

            // Act
            actual = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithInvalidLatinAlphaValue_ReturnsOneValidationResult()
        {
            // Arrange
            TestObject testValue = new TestObject() { LatinAlpha = "123" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            int expected = 1;

            // Act
            _ = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, validationResults.Count);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithInvalidPositiveIntegerValue_ReturnsFalse()
        {
            // Arrange
            TestObject testValue = new TestObject() { PositiveInteger = "-123" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            bool expected = false;
            bool actual;

            // Act
            actual = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithInvalidPositiveIntegerValue_ReturnsOneValidationResult()
        {
            // Arrange
            TestObject testValue = new TestObject() { PositiveInteger = "-123" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            int expected = 1;

            // Act
            _ = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, validationResults.Count);
        }

        [TestMethod]
        public void TryValidateObject_TestObjectWithInvalidLatinAlphaAndPositiveIntegerValues_ReturnsTwoValidationResults()
        {
            // Arrange
            TestObject testValue = new TestObject() { LatinAlpha="123", PositiveInteger = "-123" };
            ValidationContext validationContext = CreateValidationContext(testValue);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            int expected = 2;

            // Act
            _ = Validator.TryValidateObject(testValue, validationContext, validationResults, true);

            // Assert
            Assert.AreEqual(expected, validationResults.Count);
        }

        #region Private Helper Methods

        private ValidationContext CreateValidationContext(object itemToValidate)
        {
            return new ValidationContext(itemToValidate, _validationTestFactory.GetServiceProvider(), new Dictionary<object, object>());
        }

        #endregion

        #region Private Helper Types

        private class TestObject
        {
            [CharacterSet(BuiltInRules.CharacterSet.LatinAlpha)]
            public string LatinAlpha { get; set; } = "LatinAlpha";

            [CharacterSet(BuiltInRules.CharacterSet.PositiveInteger)]
            public string PositiveInteger { get; set; } = "123";
        }

        #endregion
    }
}
