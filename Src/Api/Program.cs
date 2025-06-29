using Api.Common.Logging;
using Api.Common.Swagger;
using Api.Configurations;
using Api.Middlewares;
using Application;
using Application.Common.Helpers;
using Application.Common.Seeders;
using Infrastructure;

try
{
	var builder = WebApplication.CreateBuilder(args);
	var configuration = builder.Configuration;

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();

	#region Main dependencies
	builder.AddLoggingSetup();
	builder.AddConfiguration();
	builder.Services.AddSwaggerSetup();
	#endregion

	#region Layers dependencies
	builder.Services.AddInfrastructure(configuration);
	builder.Services.AddApplication(configuration); 
	#endregion

	var app = builder.Build();

	#region Initialization
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

	app.UseAuthentication();
	app.UseMiddlewares();
	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	ConsoleHelper.WriteLine("[Error]", $"Detail: {ex}");
}