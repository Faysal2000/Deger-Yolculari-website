
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.DTOs.Events;



namespace deger_yolculari.Application.Interfaces
{
    public interface IEventService
    {

        Task<PagedResult<EventDto>> GetAllAsync(PaginationParams paginationParams, bool publishedOnly = true);
        Task<ApiResponse<EventDto>> GetByIdAsync(Guid id);
        Task<ApiResponse<EventDto>> CreateAsync(Guid adminId, CreateEventDto dto);
        Task<ApiResponse<EventDto>> UpdateAsync(Guid adminId, Guid id, UpdateEventDto dto);
        Task<ApiResponse<bool>> DeleteAsync(Guid adminId, Guid id);
        Task<ApiResponse<bool>> PublishAsync(Guid adminId, Guid id);
        Task<ApiResponse<bool>> UnpublishAsync(Guid adminId, Guid id);
    }
}
