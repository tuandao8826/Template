using Api.Common.Swagger;
using Api.Configurations;
using Application;
using Application.Common.Seeders;
using Infrastructure;

try
{
	var builder = WebApplication.CreateBuilder(args);
	var configuration = builder.Configuration;

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();

	#region Swagger
	builder.Services.AddSwaggerSetup();
	#endregion

	#region Configurations
	builder.AddConfiguration();
	#endregion

	#region Dependencies
	builder.Services.AddInfrastructure(configuration);
	builder.Services.AddApplication(configuration); 
	#endregion

	var app = builder.Build();

	#region Seeder
	await app.Services.InitializeSeedDataAsync(); 
	#endregion

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/swagger/Admin/swagger.json", "Admin API");
			options.SwaggerEndpoint("/swagger/Public/swagger.json", "Public API");
		});
	}

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	Console.WriteLine($"-----> [Error] detail: {ex}");
}