using FluentValidation;
using FastEndpoints;

public class LoginValidator : Validator<LoginRequest>
{
	public LoginValidator()
	{
		RuleFor(x => x.Email).NotEmpty().EmailAddress();
		RuleFor(x => x.Password).NotEmpty().Length(6, 20);
	}
}