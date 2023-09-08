using MediatR;
using stone_21.Commands;
using stone_21.Data;
using stone_21.Services;

namespace stone_21.Handlers;

public class HireApplicantHandler : IRequestHandler<HireApplicant, int>
{
    private readonly ILogger<HireApplicantHandler> _logger;
    private readonly HRDepartmentService _hrDepartmentService;

    public HireApplicantHandler(HRDepartmentService hRDepartmentService, ILogger<HireApplicantHandler> logger)
    {
        _logger = logger;
        _hrDepartmentService = hRDepartmentService;
    }

    public async Task<int> Handle(HireApplicant request, CancellationToken cancellationToken)
    {
        Applicant? applicant = _hrDepartmentService.HRDepartment.Applicants.FirstOrDefault(apl => apl.Id == request.applicantId);
        if (applicant is null)
        {
            throw new KeyNotFoundException($"applicant with ID = {request.applicantId} not found");
        }

        applicant.Hire();
        Employee newEmployee = new(applicant);

        // TODO: replace this with actual awaitable DB logic that adds applicant as new employee
        _hrDepartmentService.HRDepartment.Employees = _hrDepartmentService.HRDepartment.Employees.Append(newEmployee);

        return applicant.Id;
    }
}
