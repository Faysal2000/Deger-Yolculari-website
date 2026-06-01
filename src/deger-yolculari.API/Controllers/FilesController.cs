using System.Security.Claims;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Files;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<FileDocumentDto>>> GetAll([FromQuery] PaginationParams p)
    {
        var result = await _fileService.GetFilesAsync(p);
        return Ok(result);
    }

    [HttpPost("upload")]
    [Authorize(Roles = "Admin")]
    [RequestSizeLimit(100 * 1024 * 1024)]
    [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
    public async Task<ActionResult<ApiResponse<FileDocumentDto>>> Upload(IFormFile file)
    {
        var adminId = GetCurrentUserId();
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var result = await _fileService.UploadFileAsync(adminId, file, baseUrl);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("upload-image")]
    [Authorize(Roles = "Admin")]
    [RequestSizeLimit(100 * 1024 * 1024)]
    [RequestFormLimits(MultipartBodyLengthLimit = 100 * 1024 * 1024)]
    public async Task<ActionResult<ApiResponse<string>>> UploadImage(IFormFile file)
    {
        var adminId = GetCurrentUserId();
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var result = await _fileService.UploadImageAsync(adminId, file, baseUrl);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(Guid id)
    {
        var adminId = GetCurrentUserId();
        var result = await _fileService.DeleteFileAsync(adminId, id);
        return result.Success ? Ok(result) : NotFound(result);
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
    }
}
