namespace AutoMapperSample.Models;

public class WeatherForecastViewModel
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}
