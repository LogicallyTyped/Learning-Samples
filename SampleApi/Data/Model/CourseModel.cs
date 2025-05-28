namespace Template.API.Data.Model;

public class CourseModel
{
    public int Id { get; set; }
    public bool IsPreorder { get; set; }
    public required string CourseUrl { get; set; }
    public required string CourseType { get; set; }
    public required string CourseName { get; set; }
    public int CourseLessonCount { get; set; }
    public float CourseLengthInHours { get; set; }
    public required string ShortDescription { get; set; }
    public required string CourseImage { get; set; }
    public int PriceInUSD { get; set; }
    public string? CoursePreviewLink { get; set; }
}
