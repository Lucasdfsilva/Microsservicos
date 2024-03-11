using AutoMapper;
using Data.Models;
using GeekShoppingAPI.Data.ValueObject;

namespace GeekShoppingAPI.Models.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mpconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mpconfig;
        }
    }
}
