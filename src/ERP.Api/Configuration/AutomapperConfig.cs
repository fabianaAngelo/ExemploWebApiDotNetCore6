using AutoMapper;
using ERP.Api.ViewModels.Exemplos;
using ERP.Business.Models;
using Microsoft.Extensions.Localization;

namespace ERP.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ExemploUpdateViewModel, Exemplo>();
        }
    }
}
