using System.Security.Claims;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.News;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<NewsDto>>> GetAll([FromQuery] PaginationParams p)
    {
        var result = await _newsService.GetAllAsync(p, publishedOnly: true);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NewsDto>> GetById(Guid id)
    {
        var result = await _newsService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<NewsDto>>> GetAllAdmin([FromQuery] PaginationParams p)
    {
        var result = await _newsService.GetAllAsync(p, publishedOnly: false);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<NewsDto>> Create([FromBody] CreateNewsDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _newsService.CreateAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<NewsDto>> Update(Guid id, [FromBody] UpdateNewsDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _newsService.UpdateAsync(adminId, id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _newsService.DeleteAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id}/publish")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Publish(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _newsService.PublishAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id}/unpublish")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Unpublish(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _newsService.UnpublishAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}