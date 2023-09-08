using MediatR;

namespace stone_21.Commands;

public class HireApplicant : IRequest<int>
{
    public int applicantId { get; set; }
}

