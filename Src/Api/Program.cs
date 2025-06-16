using Application;
using Infrastructure;

try
{
	var builder = WebApplication.CreateBuilder(args);

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	builder.Services.AddInfrastructure();
	builder.Services.AddApplication();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	Console.WriteLine($"-----> [Error] detail: {ex}");
}