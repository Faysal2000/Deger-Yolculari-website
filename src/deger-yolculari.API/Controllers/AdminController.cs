using deger_yolculari.Application.DTOs.Admin;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("dashboard")]
    public async Task<ActionResult<ApiResponse<DashboardStatsDto>>> GetDashboard()
    {
        var result = await _adminService.GetDashboardStatsAsync();
        return Ok(result);
    }

    [HttpGet("audit-logs")]
    public async Task<ActionResult<PagedResult<AuditLogDto>>> GetAuditLogs([FromQuery] PaginationParams p)
    {
        var result = await _adminService.GetAuditLogsAsync(p);
        return Ok(result);
    }
}