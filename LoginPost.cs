using FastEndpoints;
using FastEndpoints.Security;

public class LoginPost : Endpoint<LoginRequest>
{
	public override void Configure()
	{
		Post("/login");
		AllowAnonymous();
	}

	public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
	{
		if (request.Email != "hello@domain.com" || request.Password != "secretpassword") {
			await SendUnauthorizedAsync(cancellationToken);
			return;
		}

		await CookieAuth.SignInAsync(user =>
		{
			user.Claims.Add(new("role", "Admin"));
			user["Email"] = "hello@domain.com";
		});

		await SendOkAsync($"Logged in as {request.Email}", cancellationToken);
	}
}