using FastEndpoints;
using FastEndpoints.Security;

public class LogoutPost : EndpointWithoutRequest
{
	public override void Configure()
	{
		Post("/logout");
	}

	public override async Task HandleAsync(CancellationToken cancellationToken)
	{
		await CookieAuth.SignOutAsync();
		await SendOkAsync($"Logged out!", cancellationToken);
	}
}