using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.contollers{
[ApiController]
[Route("controller")]
public class Weatherforecastcontroller: ControllerBase
{
    private readonly string[] _summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
[HttpGet("",Name ="Weatherforecast")]
  public IEnumerable<Weatherforecast> getfivedayforecasts()
  {
     var forecast =  Enumerable.Range(1, 5).Select(index =>
        new Weatherforecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            _summaries[Random.Shared.Next(_summaries.Length)]
        ))
        .ToArray();
    return forecast;
  }
}
public record Weatherforecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
}
