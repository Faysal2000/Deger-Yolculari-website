using System.Security.Claims;
using deger_yolculari.Application.DTOs.Articles;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticlesController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<ArticleDto>>> GetAll([FromQuery] PaginationParams p)
    {
        var result = await _articleService.GetAllAsync(p, publishedOnly: true);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDto>> GetById(Guid id)
    {
        var result = await _articleService.GetByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<ArticleDto>>> GetAllAdmin([FromQuery] PaginationParams p)
    {
        var result = await _articleService.GetAllAsync(p, publishedOnly: false);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ArticleDto>> Create([FromBody] CreateArticleDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _articleService.CreateAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ArticleDto>> Update(Guid id, [FromBody] UpdateArticleDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _articleService.UpdateAsync(adminId, id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _articleService.DeleteAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}