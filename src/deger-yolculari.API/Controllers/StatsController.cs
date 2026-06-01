using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Stats;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public StatsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<PublicStatsDto>>> GetStats()
    {
        var totalDonors = await _uow.Donations.Query()
            .Where(d => d.Status == "Success")
            .Select(d => d.DonorEmail)
            .Distinct()
            .CountAsync();

        var totalDonationsAmount = await _uow.Donations.Query()
            .Where(d => d.Status == "Success")
            .SumAsync(d => (decimal?)d.Amount) ?? 0m;

        var activeCampaigns = await _uow.DonationCampaigns.CountAsync(c => c.IsOpen);

        var newsletterSubscribers = await _uow.NewsletterSubscribers
            .CountAsync(s => s.IsActive && s.IsConfirmed);

        var settings = await _uow.SiteSettings.Query().FirstOrDefaultAsync();
        var beneficiaries = settings?.Beneficiaries ?? "5.000+";

        return Ok(ApiResponse<PublicStatsDto>.Ok(new PublicStatsDto
        {
            TotalDonors = totalDonors,
            TotalDonationsAmount = totalDonationsAmount,
            ActiveCampaigns = activeCampaigns,
            NewsletterSubscribers = newsletterSubscribers,
            Beneficiaries = beneficiaries,
        }));
    }
}
