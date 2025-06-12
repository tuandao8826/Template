using Api.Tests.Entities;
using Core.Commons.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tests;

public class WeatherForecastController : BaseController
{
    private static readonly string[] Summaries =
	[
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

	[HttpGet("GetWeatherForecast")]
	public ActionResult<SuccessResultResponse<IEnumerable<WeatherForecast>>> Get()
	{
		var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		});

		return ResultResponse(response, "Success");
	}
}
