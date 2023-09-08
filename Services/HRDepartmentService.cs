using MediatR;
using stone_21.Data;

namespace stone_21.Services;

public class HRDepartmentService
{
    private readonly ILogger<HRDepartmentService> _logger;
    private readonly IMediator _mediator;
    public HumanResources HRDepartment;

    public HRDepartmentService(ILogger<HRDepartmentService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        HRDepartment = new HumanResources();

        HRDepartment.Applicants = HRDepartment.Applicants.Append(new Applicant(1) { Name = "Новый", Surname = "Кандидат" });
        HRDepartment.Applicants = HRDepartment.Applicants.Append(new Applicant(2) { Name = "Старый", Surname = "Кандидат" });
        HRDepartment.Employees = HRDepartment.Employees.Append(new Employee(3) { Name = "Vova", Surname = "IVanov" });
        HRDepartment.Employees = HRDepartment.Employees.Append(new Employee(4) { Name = "Dasha", Surname = "Frolova" });
    }
}
