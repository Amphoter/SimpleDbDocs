using AutoMapper;
using DbDocsGenerator.Models;
using DbDocsGenerator.Models.SqlServer;

namespace DbDocsGenerator.Mapping
{
    public static class MapperInitializer
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<InformationSchema, Column>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ColumnName))
                    .ForMember(dest => dest.DataType, opt => opt.MapFrom(src => src.DataType))
                    .ForMember(dest => dest.IsNullable, opt => opt.MapFrom(src => src.IsNullable))
                    .ForMember(dest => dest.NumericPrecision, opt => opt.MapFrom(src => src.NumericPrecision))
                    .ForMember(dest => dest.NumericScale, opt => opt.MapFrom(src => src.NumericScale))
                    .ForMember(dest => dest.CharacterMaxLength, opt => opt.MapFrom(src => src.CharacterMaxLength));
            });

            return config.CreateMapper();
        }
    }
}
