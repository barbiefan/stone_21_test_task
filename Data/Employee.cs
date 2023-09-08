namespace stone_21.Data;

public class Employee : Person
{
    public Employee(int id) : base(id) { }
    public Employee(Applicant applicant) : base(applicant.Id)
    {
        Name = applicant.Name;
        Surname = applicant.Surname;
        Patronymic = applicant.Patronymic;
    }
}
