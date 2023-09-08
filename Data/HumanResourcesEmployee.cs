namespace stone_21.Data;

public class HumanResourcesEmployee : Employee
{
    public IEnumerable<Applicant> Applicants;
    public IEnumerable<Person> Employees;

    public HumanResourcesEmployee(int id) : base(id)
    {
        this.Applicants = new List<Applicant>();
        this.Employees = new List<Person>();
    }

    public HumanResourcesEmployee(int id, IEnumerable<Applicant> applicants) : base(id)
    {
        this.Applicants = applicants;
        this.Employees = new List<Person>();
    }

    public HumanResourcesEmployee(int id, IEnumerable<Employee> employees) : base(id)
    {
        this.Applicants = new List<Applicant>();
        this.Employees = employees;
    }

    public HumanResourcesEmployee(int id, IEnumerable<Applicant> applicants, IEnumerable<Employee> employees) : base(id)
    {
        this.Applicants = applicants;
        this.Employees = employees;
    }
}
