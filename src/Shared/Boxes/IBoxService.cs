using System.Threading.Tasks;

namespace Shared.Boxes
{
    public interface IBoxService
    {
        Task<BoxResponse.GetIndex> GetIndexAsync(BoxRequest.GetIndex request);
        Task<BoxResponse.GetDetail> GetDetailAsync(BoxRequest.GetDetail request);
        Task DeleteAsync(BoxRequest.Delete request);
        Task<BoxResponse.Create> CreateAsync(BoxRequest.Create request);
        Task<BoxResponse.Edit> EditAsync(BoxRequest.Edit request);
    }
}
