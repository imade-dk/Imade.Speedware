namespace Imade.Speedware.Api.Models;

public partial class Lesson
{
    public int LessonId { get; set; }
    public int MaxNumberOfStudents { get; set; }
    public bool WaitinglistOverFlow { get; set; }
    public int StudentCount { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Teachers { get; set; }
    public string? School { get; set; }
    public string? Room { get; set; }
    public int CourseId { get; set; }
    public int SchoolId { get; set; }
    public string? CourseName { get; set; }
    public string? CourseType { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? Season { get; set; }
    public string? FeeName { get; set; }
    public float YearPrice { get; set; }
    public int NumberOfLessons { get; set; }
    public float LessonLength { get; set; }
    public string? DirectLink { get; set; }
    public bool Active { get; set; }
    public bool AllowSignup { get; set; }
    public bool InActiveSignupTree { get; set; }
}
