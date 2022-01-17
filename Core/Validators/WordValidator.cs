using Core.Dtos;
using FluentValidation;

namespace Core.Validators
{
    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(word => word.Value)
                .NotEmpty().WithMessage("Word cannot be empty.")
                .Length(3, 6).WithMessage("Words can only be of length 3 to 6.")
                .Must(word => word.All(char.IsLetter)).WithMessage("Words can only contain letters");
        }
    }
}