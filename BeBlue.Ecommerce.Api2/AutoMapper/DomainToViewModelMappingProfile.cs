using AutoMapper;
using BeBlue.Ecommerce.Api2.ViewModels;
using BeBlue.Ecommerce.Domain.Models;
using System;


namespace BeBlue.Ecommerce.Api2.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<VendaViewModel, Venda>()
                .ForMember(d => d.DataVenda, o => o.MapFrom(s => Convert.ToDateTime(s.DataVenda)));
        }
    }
}