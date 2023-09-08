namespace stone_21.Data;

public class HumanResources
{
    public IEnumerable<Employee> Employees;
    private HumanResources HRDepartment;
    public IEnumerable<Applicant> Applicants;

    public HumanResources()
    {
        this.Employees = new List<Employee>();
        this.Applicants = new List<Applicant>();
    }

    public HumanResources(IEnumerable<Employee> employees)
    {
        this.Employees = employees;
        this.Applicants = new List<Applicant>();
    }

    public HumanResources(IEnumerable<Applicant> applicants)
    {
        this.Employees = new List<Employee>();
        this.Applicants = applicants;
    }

    public HumanResources(IEnumerable<Employee> employees, IEnumerable<Applicant> applicants)
    {
        this.Employees = employees;
        this.Applicants = applicants;
    }
}
