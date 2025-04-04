using Application.Dtos;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers;

[Route("api/values")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IValuesRepo _valueRepo;
    public ValuesController(IValuesRepo valueRepo)
    {
        _valueRepo = valueRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetValues([FromQuery] FilterModel filter)
    {
        var response = await _valueRepo.GetValues(filter);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddValues(IEnumerable<AddValueDto> data)
    {
        await _valueRepo.AddValues(data);

        return Ok();
    }
}
