using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using RechercheService.Models;

namespace RechercheService.Controllers;

[ApiController]
[Route("api/recherche")]
public class RechercheController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Produit>>> RechercheProduits(string searchTerm)
    {
        var query = DB.Find<Produit>();
        query.Sort(x => x.Ascending(a => a.Make));

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query.Match(Search.Full, searchTerm).SortByTextScore();
        }

        var result = await query.ExecuteAsync();

        return result;
    }
}
