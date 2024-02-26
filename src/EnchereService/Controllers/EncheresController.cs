using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using EnchereService.Data;
using EnchereService.DTOs;
using EnchereService.Entities;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnchereService.Controllers;

[ApiController]
[Route("api/encheres")]
public class EncheresController : ControllerBase
{
    private readonly EnchereDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public EncheresController(EnchereDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<List<EnchereDto>>> GetAllEncheres(string date)
    {
        var query = _context.Encheres.OrderBy(x => x.Produit.Make).AsQueryable();

        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<EnchereDto>(_mapper.ConfigurationProvider).ToListAsync();
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

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<EnchereDto>> CreateEnchere(CreateEnchereDto enchereDto)
    {
        var enchere = _mapper.Map<Enchere>(enchereDto);

        enchere.Seller = User.Identity.Name;

        _context.Encheres.Add(enchere);

        var newEnchere = _mapper.Map<EnchereDto>(enchere);

        await _publishEndpoint.Publish(_mapper.Map<EnchereCreated>(newEnchere));

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Impossible de sauvegarder en base");

        return CreatedAtAction(nameof(GetEnchereById),
        new { enchere.Id }, _mapper.Map<EnchereDto>(enchere));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEnchere(Guid id, UpdateEnchereDto updateEnchereDto)
    {
        var enchere = await _context.Encheres.Include(x => x.Produit)
        .FirstOrDefaultAsync(x => x.Id == id);
        if (enchere == null) return NotFound();

        if (enchere.Seller != User.Identity.Name) return Forbid();

        enchere.Produit.Make = updateEnchereDto.Make ?? enchere.Produit.Make;
        enchere.Produit.ProductName = updateEnchereDto.ProductName ?? enchere.Produit.ProductName;
        enchere.Produit.Color = updateEnchereDto.Color ?? enchere.Produit.Color;
        enchere.Produit.Size = updateEnchereDto.Size ?? enchere.Produit.Size;
        enchere.Produit.Year = updateEnchereDto.Year ?? enchere.Produit.Year;
        enchere.Produit.Comments = updateEnchereDto.Comments ?? enchere.Produit.Comments;

        await _publishEndpoint.Publish<EnchereUpdated>(_mapper.Map<EnchereUpdated>(enchere));

        var result = await _context.SaveChangesAsync() > 0;

        if (result) return Ok();

        return BadRequest("Erreur lors de la sauvegarde");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEnchere(Guid id)
    {
        var enchere = await _context.Encheres.FindAsync(id);

        if (enchere == null) return NotFound();

        if (enchere.Seller != User.Identity.Name) return Forbid();

        _context.Encheres.Remove(enchere);

        await _publishEndpoint.Publish<EnchereDeleted>(new EnchereDeleted { Id = enchere.Id.ToString() });

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Impossible de mettre à jour la base");

        return Ok();
    }

}
