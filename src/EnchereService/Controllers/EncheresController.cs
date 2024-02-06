using AutoMapper;
using EnchereService.Data;
using EnchereService.DTOs;
using EnchereService.Entities;
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

    [HttpPost]
    public async Task<ActionResult<EnchereDto>> CreateEnchere(CreateEnchereDto enchereDto)
    {
        var enchere = _mapper.Map<Enchere>(enchereDto);
        // TODO : add current user as seller
        enchere.Seller = "test";

        _context.Encheres.Add(enchere);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Impossible de sauvegarder en base");

        return CreatedAtAction(nameof(GetEnchereById),
        new { enchere.Id }, _mapper.Map<EnchereDto>(enchere));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEnchere(Guid id, UpdateEnchereDto updateEnchereDto)
    {
        var enchere = await _context.Encheres.Include(x => x.Produit)
        .FirstOrDefaultAsync(x => x.Id == id);
        if (enchere == null) return NotFound();

        //TODO : check seller == username

        enchere.Produit.Make = updateEnchereDto.Make ?? enchere.Produit.Make;
        enchere.Produit.ProductName = updateEnchereDto.ProductName ?? enchere.Produit.ProductName;
        enchere.Produit.Color = updateEnchereDto.Color ?? enchere.Produit.Color;
        enchere.Produit.Size = updateEnchereDto.Size ?? enchere.Produit.Size;
        enchere.Produit.Year = updateEnchereDto.Year ?? enchere.Produit.Year;
        enchere.Produit.Comments = updateEnchereDto.Comments ?? enchere.Produit.Comments;

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Erreur lors de la sauvegarde");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEnchere(Guid id)
    {
        var enchere = await _context.Encheres.FindAsync(id);

        if (enchere == null) return NotFound();

        //TODO : check seller == username

        _context.Encheres.Remove(enchere);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Impossible de mettre à jour la base");

        return Ok();
    }

}
