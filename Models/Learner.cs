namespace Lab.Models;

public class Learner
{
    public int LearnerId { get; set; }
    public string? LastName { get; set; }
    public string? FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public int MajorId { get; set; }
}