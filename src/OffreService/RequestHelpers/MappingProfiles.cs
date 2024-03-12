using AutoMapper;

namespace OffreService;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Offre, OffreDto>();
    }
}
