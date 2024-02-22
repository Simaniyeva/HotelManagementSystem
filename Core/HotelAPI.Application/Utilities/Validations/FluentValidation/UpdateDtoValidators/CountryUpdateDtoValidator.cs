﻿namespace HotelAPI.Application.Utilities.Validations.FluentValidation.UpdateDtoValidators;

public class CountryUpdateDtoValidator : AbstractValidator<CountryPostDto>
{
    public CountryUpdateDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Don't Enter Null ")
            .MinimumLength(2)
            .MaximumLength(255)
            .Must(ValidName)
            .WithMessage(Messages.EnterValid(Messages.Country));
    }

    private bool ValidName(string name)
    {
        if (name is null)
        {
            return false;
        }
        var nameRegex = @"^[A-Z]+[a-zA-Z]*$|[A-Z]+[a-zA-Z]+[\s][A-Z]+[a-zA-Z]*$";
        Regex regex = new(nameRegex);

        if (regex.IsMatch(name))
        {
            return true;
        }
        return false;
    }
}
