using System.Text.Json.Serialization;

namespace stone_21.Data;

public enum ApplicantStatus
{
    New,
    Assessed,
    Interviewed,
    GivenTestTask,
    DoneTestTask,
    Hired,
    Rejected,
}

public class Applicant : Person
{
    private ApplicantStatus _status;

    [JsonPropertyName("Status")]
    public ApplicantStatus Status
    {
        get
        {
            return this._status;
        }
        set
        {
            if (this._status != ApplicantStatus.Rejected && this._status != ApplicantStatus.Hired)
            {
                this._status = value;
            };
        }
    }

    [JsonPropertyName("AppliedDateTime")]
    public DateTime AppliedDateTime;

    [JsonPropertyName("TaskGivenDateTime")]
    public DateTime? TaskGivenDateTime;

    [JsonPropertyName("TaskDoneDateTime")]
    public DateTime? TaskDoneDateTime;

    public Applicant(int id) : base(id)
    {
        this.Status = ApplicantStatus.New;
        this.AppliedDateTime = DateTime.Now;
    }

    public void Reject()
    {
        this.Status = ApplicantStatus.Rejected;
    }

    public void MakeAssessment()
    {
        this.Status = ApplicantStatus.Assessed;
    }

    public void Interview()
    {
        this.Status = ApplicantStatus.Interviewed;
    }

    public void GiveTask()
    {
        if (this.Status != ApplicantStatus.Rejected)
        {
            this.Status = ApplicantStatus.GivenTestTask;
            this.TaskGivenDateTime = DateTime.Now;
        }
    }

    public void TakeTestTaskResult()
    {
        this.Status = ApplicantStatus.DoneTestTask;
        this.TaskDoneDateTime = DateTime.Now;
    }

    public void Hire()
    {
        this.Status = ApplicantStatus.Hired;
    }
}
