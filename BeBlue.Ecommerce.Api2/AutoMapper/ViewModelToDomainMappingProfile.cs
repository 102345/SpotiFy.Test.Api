using AutoMapper;
using BeBlue.Ecommerce.Api2.ViewModels;
using BeBlue.Ecommerce.Domain.Models;

namespace BeBlue.Ecommerce.Api2.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Venda, VendaViewModel>();


        }
    }
}