using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using RechercheService.Models;
using RechercheService.RequestHelpers;

namespace RechercheService.Controllers;

[ApiController]
[Route("api/recherche")]
public class RechercheController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Produit>>> RechercheProduits([FromQuery] RechercheParams rechercheParams)
    {
        var query = DB.PagedSearch<Produit, Produit>();

        if (!string.IsNullOrEmpty(rechercheParams.SearchTerm))
        {
            query.Match(Search.Full, rechercheParams.SearchTerm).SortByTextScore();
        }

        query = rechercheParams.OrderBy switch
        {
            "make" => query.Sort(x => x.Ascending(a => a.Make)),
            "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
            _ => query.Sort(x => x.Ascending(a => a.AuctionEnd))
        };

        query = rechercheParams.FilterBy switch
        {
            "finished" => query.Match(x => x.AuctionEnd < DateTime.UtcNow),
            "endingSoon" => query.Match(x => x.AuctionEnd < DateTime.UtcNow.AddHours(6) && x.AuctionEnd > DateTime.UtcNow),
            _ => query.Match(x => x.AuctionEnd > DateTime.UtcNow)
        };

        if (!string.IsNullOrEmpty(rechercheParams.Seller))
        {
            query.Match(x => x.Seller == rechercheParams.Seller);
        }
        if (!string.IsNullOrEmpty(rechercheParams.Winner))
        {
            query.Match(x => x.Winner == rechercheParams.Winner);
        }

        query.PageNumber(rechercheParams.PageNumber);
        query.PageSize(rechercheParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            results = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}
