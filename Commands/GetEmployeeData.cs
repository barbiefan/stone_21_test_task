using MediatR;
using stone_21.Data;

namespace stone_21.Commands;

public class GetEmployeeData : IRequest<Employee>
{
    public int employeeId { get; set; }
}

