using Application;
using Infrastructure;

try
{
	var builder = WebApplication.CreateBuilder(args);
	var configuration = builder.Configuration;

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	#region Dependencies
	builder.Services.AddInfrastructure();
	builder.Services.AddApplication(); 
	#endregion

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