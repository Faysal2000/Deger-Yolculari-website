using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Newsletter;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController : ControllerBase
{
    private readonly INewsletterService _newsletterService;

    public NewsletterController(INewsletterService newsletterService)
    {
        _newsletterService = newsletterService;
    }

    [HttpPost("subscribe")]
    public async Task<ActionResult<ApiResponse<bool>>> Subscribe([FromBody] SubscribeDto dto)
    {
        var result = await _newsletterService.SubscribeAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("confirm/{token}")]
    public async Task<ActionResult<ApiResponse<bool>>> Confirm(string token)
    {
        var result = await _newsletterService.ConfirmSubscriptionAsync(token);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("unsubscribe/{token}")]
    public async Task<ActionResult<ApiResponse<bool>>> Unsubscribe(string token)
    {
        var result = await _newsletterService.UnsubscribeAsync(token);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("subscribers")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PagedResult<NewsletterSubscriberDto>>> GetSubscribers([FromQuery] PaginationParams p)
    {
        var result = await _newsletterService.GetSubscribersAsync(p);
        return Ok(result);
    }
}