using AutoMapper;
using IDSC_Project.CORE.Models;
using IDSC_Project.CORE.ViewModels;

namespace IDSC_Project.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Product,EditProductViewModel>().ReverseMap();
        CreateMap<Product,CreateProductViewModel>().ReverseMap();
    }
}
