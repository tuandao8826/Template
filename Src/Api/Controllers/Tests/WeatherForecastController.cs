using Api.Common.ControllerWrappers;
using Api.Tests.Entities;
using Application.Common.ApiWrappers;
using Application.Common.Definitions;
using Application.Modules.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tests;

public class WeatherForecastController : BaseController
{
    private static readonly string[] Summaries =
	[
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

	[HttpGet]
	public ActionResult<SuccessResultResponse<IEnumerable<WeatherForecast>>> Get()
	{
		var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		});

		return ResultResponse(response, Message<User>.View());
	}
}
