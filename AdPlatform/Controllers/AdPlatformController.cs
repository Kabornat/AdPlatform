using Microsoft.AspNetCore.Mvc;

namespace AdPlatform.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdPlatformController(AdPlatformRepository adPlatformRepository) : ControllerBase
{
    private readonly AdPlatformRepository _adPlatformRepository = adPlatformRepository;


    [HttpGet]
    public IActionResult Search([FromQuery] string location)
    {
        if (string.IsNullOrEmpty(location))
            return BadRequest("Не указана локация для поиска");

        var platforms = _adPlatformRepository.GetByLocation(location);

        return Ok(platforms);
    }

    [HttpPost]
    public async Task<IActionResult> LoadFromFile(IFormFile formFile)
    {
        if (formFile is null)
            return BadRequest("Файл не может быть пустым");

        var responce = await _adPlatformRepository.Load(formFile);

        return Ok(responce);
    }
}
