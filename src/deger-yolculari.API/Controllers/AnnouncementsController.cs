using System.Security.Claims;
using deger_yolculari.Application.DTOs.Announcements;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementsController : ControllerBase
{
    private readonly IAnnouncementService _announcementService;

    public AnnouncementsController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<AnnouncementDto>>> GetAll([FromQuery] PaginationParams p)
    {
        var result = await _announcementService.GetAllAsync(p, activeOnly: true);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AnnouncementDto>> GetById(Guid id)
    {
        var result = await _announcementService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<AnnouncementDto>>> GetAllAdmin([FromQuery] PaginationParams p)
    {
        var result = await _announcementService.GetAllAsync(p, activeOnly: false);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AnnouncementDto>> Create([FromBody] CreateAnnouncementDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _announcementService.CreateAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AnnouncementDto>> Update(Guid id, [FromBody] UpdateAnnouncementDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _announcementService.UpdateAsync(adminId, id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _announcementService.DeleteAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}