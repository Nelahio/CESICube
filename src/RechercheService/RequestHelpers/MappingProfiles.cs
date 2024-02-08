using AutoMapper;
using Contracts;
using RechercheService.Models;

namespace RechercheService;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EnchereCreated, Produit>();
    }
}
