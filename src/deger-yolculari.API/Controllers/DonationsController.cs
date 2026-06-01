using System.Security.Claims;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Donations;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonationsController : ControllerBase
{
    private readonly IDonationService _donationService;
    private readonly IConfiguration _config;

    public DonationsController(IDonationService donationService, IConfiguration config)
    {
        _donationService = donationService;
        _config = config;
    }

    //  Campaigns 

    [HttpGet("campaigns")]
    public async Task<ActionResult<PagedResult<DonationCampaignDto>>> GetCampaigns([FromQuery] PaginationParams p)
    {
        var result = await _donationService.GetCampaignsAsync(p, openOnly: false);
        return Ok(result);
    }

    [HttpGet("campaigns/open")]
    public async Task<ActionResult<PagedResult<DonationCampaignDto>>> GetOpenCampaigns([FromQuery] PaginationParams p)
    {
        var result = await _donationService.GetCampaignsAsync(p, openOnly: true);
        return Ok(result);
    }

    [HttpGet("campaigns/{id}")]
    public async Task<ActionResult<DonationCampaignDto>> GetCampaignById(Guid id)
    {
        var result = await _donationService.GetCampaignByIdAsync(id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost("campaigns")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DonationCampaignDto>> CreateCampaign([FromBody] CreateCampaignDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _donationService.CreateCampaignAsync(adminId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("campaigns/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<DonationCampaignDto>> UpdateCampaign(Guid id, [FromBody] UpdateCampaignDto dto)
    {
        var adminId = GetCurrentUserId();
        var result = await _donationService.UpdateCampaignAsync(adminId, id, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("campaigns/{id}/toggle")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> ToggleCampaign(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _donationService.ToggleCampaignAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete("campaigns/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<bool>> DeleteCampaign(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _donationService.DeleteCampaignAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    //  Donations 

    [HttpPost("donate")]
    public async Task<ActionResult<DonationDto>> Donate([FromBody] InitiateDonationDto dto)
    {
        var claim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        Guid? userId = Guid.TryParse(claim, out var id) ? id : null;
        var result = await _donationService.InitiateDonationAsync(userId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("initiate")]
    public async Task<ActionResult<ThreeDSInitiateResponseDto>> Initiate([FromBody] InitiateDonationDto dto)
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Guid? userId = Guid.TryParse(claim, out var id) ? id : null;
        var result = await _donationService.InitiateThreeDSAsync(userId, dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("iyzico-callback")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> IyzicoCallback([FromForm] IyzicoCallbackDto dto)
    {
        var redirectUrl = await _donationService.HandleCallbackAsync(dto);
        // Use window.top to break out of the 3DS iframe and navigate the full page
        var html = $"<!DOCTYPE html><html><body><script>window.top.location.href='{redirectUrl}';</script></body></html>";
        return Content(html, "text/html");
    }

    [HttpGet("config")]
    public IActionResult GetDonationConfig()
    {
        var apiKey = _config["Iyzico:ApiKey"] ?? string.Empty;
        return Ok(new { isSandbox = apiKey.StartsWith("sandbox-") });
    }

    [HttpGet("my-donations")]
    [Authorize]
    public async Task<ActionResult<PagedResult<DonationDto>>> GetMyDonations([FromQuery] PaginationParams p)
    {
        var userId = GetCurrentUserId();
        var result = await _donationService.GetUserDonationsAsync(userId, p);
        return Ok(result);
    }

    [HttpGet("{donationId}/certificate")]
    public async Task<ActionResult> GetCertificate(Guid donationId)
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Guid? userId = Guid.TryParse(claim, out var id) ? id : null;
        var result = await _donationService.GenerateCertificateAsync(donationId, userId);
        if (!result.Success)
            return BadRequest(result);
        return File(result.Data!, "application/pdf", $"bagis-sertifikasi-{donationId}.pdf");
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}