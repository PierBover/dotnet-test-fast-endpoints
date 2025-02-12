using FastEndpoints;
using FluentValidation;

public class FruitValidator : Validator<FruitRequest>
{
	public FruitValidator()
	{
		RuleFor(x => x.Name).NotEmpty().Length(3,20);
		RuleFor(x => x.Color).NotEmpty().Length(3,20);
	}
}