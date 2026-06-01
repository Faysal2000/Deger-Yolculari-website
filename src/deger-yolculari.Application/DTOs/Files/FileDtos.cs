namespace deger_yolculari.Application.DTOs.Files;

public class FileDocumentDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public int FileSizeKB { get; set; }
    public DateTime UploadedAt { get; set; }
    public string AdminName { get; set; } = string.Empty;
}
