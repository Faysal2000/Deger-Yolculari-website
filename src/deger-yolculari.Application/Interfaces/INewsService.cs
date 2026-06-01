using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.News;




namespace deger_yolculari.Application.Interfaces
{
    public interface INewsService
    {
        
        Task<PagedResult<NewsDto>> GetAllAsync(PaginationParams paginationParams, bool publishedOnly = true);
        Task<ApiResponse<NewsDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<NewsDto>> CreateAsync(Guid adminId, CreateNewsDto dto);
        Task<ApiResponse<NewsDto>> UpdateAsync(Guid adminId, Guid id, UpdateNewsDto dto);
        Task<ApiResponse<bool>> DeleteAsync(Guid adminId, Guid id);
        Task<ApiResponse<bool>> PublishAsync(Guid adminId, Guid id);
        Task<ApiResponse<bool>> UnpublishAsync(Guid adminId, Guid id);



    }
}
