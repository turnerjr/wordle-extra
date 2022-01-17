using Core.Dtos;
using Core.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace Tests
{
    public class WordValidatorTests
    {
        private readonly WordValidator _validator;

        public WordValidatorTests()
        {
            _validator = new WordValidator();
        }

        [Fact]
        public void ShouldNotValidateEmptyString()
        {
            // Arrange
            var word = new Word(1, string.Empty);

            // Act
            var result = _validator.TestValidate(word);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Value).WithErrorMessage("Word cannot be empty.");
        }

        [Theory]
        [InlineData("Failing")]
        [InlineData("As")]
        public void ShouldNotValidateStringWithMoreThanSixCharacters(string value)
        {
            // Arrange
            var word = new Word(1, value);            

            // Act
            var result = _validator.TestValidate(word);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Value).WithErrorMessage("Words can only be of length 3 to 6.");
        }

        [Fact]
        public void ShouldNotValidateStringWithNonLetters()
        {
            // Arrange
            var word = new Word(1, "asd456");

            // Act
            var result = _validator.TestValidate(word);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Value).WithErrorMessage("Words can only contain letters");
        }
    }
}