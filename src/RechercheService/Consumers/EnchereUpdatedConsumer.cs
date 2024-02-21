using AutoMapper;
using Contracts;
using MassTransit;

namespace RechercheService;

public class EnchereUpdatedConsumer : IConsumer<EnchereUpdated>
{
    private readonly IMapper _mapper;

    public EnchereUpdatedConsumer(IMapper _mapper)
    {
        this._mapper = _mapper;
    }

    public Task Consume(ConsumeContext<EnchereUpdated> context)
    {
        throw new NotImplementedException();
    }
}
