using MediatR;
using stone_21.Commands;
using stone_21.Data;
using stone_21.Services;

namespace stone_21.Handlers;

public class GetEmployeeDataHandler : IRequestHandler<GetEmployeeData, Employee>
{
    private readonly ILogger<GetEmployeeDataHandler> _logger;
    private readonly HRDepartmentService _hrDepartmentService;

    public GetEmployeeDataHandler(HRDepartmentService hRDepartmentService, ILogger<GetEmployeeDataHandler> logger)
    {
        _logger = logger;
        _hrDepartmentService = hRDepartmentService;
    }

    public async Task<Employee> Handle(GetEmployeeData commandData, CancellationToken cancellationToken)
    {
        Employee? employee = _hrDepartmentService.HRDepartment.Employees.FirstOrDefault(emp => emp.Id == commandData.employeeId);
        if (employee is null)
        {
            throw new KeyNotFoundException($"applicant with ID = {commandData.employeeId} not found");
        }

        return employee;
    }
}
