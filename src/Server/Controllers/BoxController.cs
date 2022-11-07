using Microsoft.AspNetCore.Mvc;
using Shared.Boxes;
using System.Threading.Tasks;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoxController : ControllerBase {
    
    private readonly IBoxService boxService;

    public BoxController(IBoxService boxService) {
        this.boxService = boxService;
    }

    // Krijg alle ontwerpen
    [HttpGet]
    public Task<BoxResponse.GetIndex> GetIndexAsync([FromQuery] BoxRequest.GetIndex request)
    {
        return boxService.GetIndexAsync(request);
    }

    [HttpGet("{BoxId}")]
    public Task<BoxResponse.GetDetail> GetDetailAsync([FromRoute] BoxRequest.GetDetail request)
    {
        return boxService.GetDetailAsync(request);
    }

    [HttpDelete("{BoxId}")]
    public Task DeleteAsync([FromRoute] BoxRequest.Delete request)
    {
        return boxService.DeleteAsync(request);
    }

    [HttpPost]
    public Task<BoxResponse.Create> CreateAsync([FromBody] BoxRequest.Create request)
    {
        return boxService.CreateAsync(request);
    }

    [HttpPut]
    public Task<BoxResponse.Edit> EditAsync([FromBody] BoxRequest.Edit request)
    {
        return boxService.EditAsync(request);
    }
}
