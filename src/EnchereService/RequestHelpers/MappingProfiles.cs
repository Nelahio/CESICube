using AutoMapper;
using EnchereService.DTOs;
using EnchereService.Entities;

namespace EnchereService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Enchere, EnchereDto>().IncludeMembers(x => x.Produit);
        CreateMap<Produit, EnchereDto>();
        CreateMap<CreateEnchereDto, Enchere>()
        .ForMember(d => d.Produit, o => o.MapFrom(s => s));
        CreateMap<CreateEnchereDto, Produit>();
    }
}
