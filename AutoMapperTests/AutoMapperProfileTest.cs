using AutoMapper;
using AutoMapperSample;
using AutoMapperSample.Models;

namespace AutoMapperTests;

[TestClass]
public class AutoMapperProfileTest
{
    // �p���ݩʦ����ŧi
    private string[] Summaries;

    [TestInitialize]
    public void Initial()
    {
        // ��l�ƨp���ݩʦ���
        Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", 
            "Hot", "Sweltering", "Scorching"
        };
    }

    [TestMethod]
    public void When_WeatherForecast_Mapping_Expect_WeatherForecastViewModel()
    {
        // Arrange
        DateTime now = DateTime.Now;
        IEnumerable<WeatherForecast> expected =
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        // Mapping�t�m
        var configuration = new MapperConfiguration(cfg =>
           cfg.AddProfile<WeatherForecastProfile>());
        // �t�m����
        configuration.AssertConfigurationIsValid();

        // Act
        // �إ� Mapper
        IMapper mapper = configuration.CreateMapper();
        // ���O�ഫ
        IEnumerable<WeatherForecastViewModel> actual =
            mapper.Map<IEnumerable<WeatherForecastViewModel>>(expected);

        // Assert
        Assert.IsNotNull(actual);
        Assert.IsInstanceOfType(actual, typeof(IEnumerable<WeatherForecastViewModel>));

        //foreach (WeatherForecastViewModel item in actual)
        //{
        //    item.Date.Should().HaveYear(now.Year);
        //    item.TemperatureF.Should().Be(32 + (int)(item.TemperatureC / 0.5556));
        //    item.Summary.Should().NotBeNullOrWhiteSpace();
        //}
    }
}