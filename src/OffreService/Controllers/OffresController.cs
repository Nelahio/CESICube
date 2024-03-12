using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;

namespace OffreService;

[ApiController]
[Route("api/[controller]")]
public class OffresController : ControllerBase
{
    private readonly IMapper _mapper;

    public OffresController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<OffreDto>> PlaceBid(string enchereId, int amount)
    {
        var enchere = await DB.Find<Enchere>().OneAsync(enchereId);

        if (enchere == null)
        {
            //TODO : vérifier que le ms enchere a des encheres
            return NotFound();
        }

        if (enchere.Seller == User.Identity.Name)
        {
            return BadRequest("Vous ne pouvez pas faire une offre sur votre enchère");
        }

        var offre = new Offre
        {
            Amount = amount,
            AuctionId = enchereId,
            Bidder = User.Identity.Name
        };

        if (enchere.AuctionEnd < DateTime.UtcNow)
        {
            offre.StatutOffre = StatutOffre.Finished;
        }
        else
        {
            var meilleureOffre = await DB.Find<Offre>()
                    .Match(a => a.AuctionId == enchereId)
                    .Sort(b => b.Descending(x => x.Amount))
                    .ExecuteFirstAsync();

            if (meilleureOffre != null && amount > meilleureOffre.Amount || meilleureOffre == null)
            {
                offre.StatutOffre = amount > enchere.ReservePrice
                ? StatutOffre.Accepted
                : StatutOffre.AcceptedBelowReserve;
            }

            if (meilleureOffre != null && offre.Amount <= meilleureOffre.Amount)
            {
                offre.StatutOffre = StatutOffre.TooLow;
            }
        }

        await DB.SaveAsync(offre);

        return Ok(_mapper.Map<OffreDto>(offre));
    }

    [HttpGet("{enchereId}")]
    public async Task<ActionResult<List<OffreDto>>> GetBidsForAuction(string enchereId)
    {
        var offres = await DB.Find<Offre>()
        .Match(e => e.AuctionId == enchereId)
        .Sort(o => o.Descending(e => e.BidTime))
        .ExecuteAsync();

        return offres.Select(_mapper.Map<OffreDto>).ToList();
    }
}
