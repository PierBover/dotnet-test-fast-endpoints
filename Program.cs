using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

builder.Services
.AddAuthenticationCookie(validFor: TimeSpan.FromDays(7), options => {
	// configure cookie settings
	options.Cookie.Name = "api-cookie";
	options.Cookie.SameSite = SameSiteMode.Strict;

	// when authentication fails
	options.Events.OnRedirectToLogin = context => {
		context.Response.StatusCode = StatusCodes.Status401Unauthorized;
		return Task.CompletedTask;
	};

	// when authorization fails
	options.Events.OnRedirectToAccessDenied = context => {
		context.Response.StatusCode = StatusCodes.Status403Forbidden;
		return Task.CompletedTask;
	};
})
.AddAuthorization()
.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app
.UseAuthentication()
.UseAuthorization()
.UseFastEndpoints().UseSwaggerGen();

app.Run();