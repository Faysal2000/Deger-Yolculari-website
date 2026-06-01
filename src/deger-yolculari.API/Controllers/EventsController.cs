using System.Security.Claims;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Events;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<EventDto>>> GetAll([FromQuery] PaginationParams p)
    {
        var result = await _eventService.GetAllAsync(p, publishedOnly: true);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetById(Guid id)
    {
        var result = await _eventService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<EventDto>>> GetAllAdmin([FromQuery] PaginationParams p)
    {
        var result = await _eventService.GetAllAsync(p, publishedOnly: false);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<EventDto>> Create([FromBody] CreateEventDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _eventService.CreateAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<EventDto>> Update(Guid id, [FromBody] UpdateEventDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _eventService.UpdateAsync(adminId, id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _eventService.DeleteAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id}/publish")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Publish(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _eventService.PublishAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id}/unpublish")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Unpublish(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _eventService.UnpublishAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}