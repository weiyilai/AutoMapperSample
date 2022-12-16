using AutoMapper;

namespace AutoMapperSample.Models;

public class WeatherForecastProfile : Profile
{
    public WeatherForecastProfile()
    {
        CreateMap<WeatherForecast, WeatherForecastViewModel>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.TemperatureC, opt => opt.MapFrom(src => src.TemperatureC))
            .ForMember(dest => dest.TemperatureF, opt => opt.MapFrom(src => 32 + (int)(src.TemperatureC / 0.5556)))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            ;
    }
}
