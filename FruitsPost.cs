using FastEndpoints;

public class FruitsPost : Endpoint<FruitRequest>
{
	public override void Configure()
	{
		Post("/fruits");
		AllowAnonymous();
	}

	public override async Task HandleAsync(FruitRequest request, CancellationToken cancellationToken)
	{
		await SendOkAsync($"Fruit {request.Name} is {request.Color}", cancellationToken);
	}
}