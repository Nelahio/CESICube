using AutoMapper;
using EnchereService.Data;
using EnchereService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnchereService.Controllers;

[ApiController]
[Route("api/encheres")]
public class EncheresController : ControllerBase
{
    private readonly EnchereDbContext _context;
    private readonly IMapper _mapper;

    public EncheresController(EnchereDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<EnchereDto>>> GetAllEncheres()
    {
        var encheres = await _context.Encheres
        .Include(x => x.Produit)
        .OrderBy(x => x.Produit.Make)
        .ToListAsync();

        return _mapper.Map<List<EnchereDto>>(encheres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnchereDto>> GetEnchereById(Guid id)
    {
        var enchere = await _context.Encheres
        .Include(x => x.Produit)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (enchere == null) return NotFound();

        return _mapper.Map<EnchereDto>(enchere);
    }
}
