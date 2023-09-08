using Microsoft.AspNetCore.Mvc;
using MediatR;
using stone_21.Data;
using stone_21.Commands;
using stone_21.Services;

namespace stone_21.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HRController : Controller
{
    private readonly ILogger<HRController> _logger;
    private readonly IMediator _mediator;
    private readonly HRDepartmentService _hrDepartmentSevice;

    public HRController(HRDepartmentService hRDepartmentService, ILogger<HRController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _hrDepartmentSevice = hRDepartmentService;
    }

    [HttpGet(Name = "HireApplicant")]
    public async Task<IActionResult> HireApplicant([FromQuery] HireApplicant _hireApplicantCommand, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(_hireApplicantCommand, cancellationToken);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (ArgumentException)
        {
            return Conflict();
        }
    }

    [HttpGet(Name = "GetEmployeeData")]
    public async Task<Employee> GetEmployeeData([FromQuery] GetEmployeeData _getEmployeeDataCommand, CancellationToken cancellationToken)
    {
        return await _mediator.Send(_getEmployeeDataCommand, cancellationToken);
    }
}
