using System.Security.Claims;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.SiteSettings;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiteSettingsController : ControllerBase
{
    private readonly ISiteSettingsService _siteSettingsService;

    public SiteSettingsController(ISiteSettingsService siteSettingsService)
    {
        _siteSettingsService = siteSettingsService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<SiteSettingsDto>>> GetSettings()
    {
        var result = await _siteSettingsService.GetSettingsAsync();
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<SiteSettingsDto>>> UpdateSettings(
        [FromBody] UpdateSiteSettingsDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _siteSettingsService.UpdateSettingsAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}