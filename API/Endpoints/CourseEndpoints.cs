using API.Data;

namespace API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this WebApplication app)
    {
        var courses = app.MapGroup("/courses");
        courses.MapGet("", LoadAllCourses);
        courses.MapGet("/{id}", LoadCourseById);
    }

    private static IResult LoadAllCourses(
        CourseData data,
        string? courseType,
        string? search)
    {
        var output = data.Courses;

        if (string.IsNullOrWhiteSpace(courseType) == false)
        {
            output.RemoveAll(x => string.Compare(
                x.CourseType,
                courseType,
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        if (string.IsNullOrWhiteSpace(search) == false)
        {
            output.RemoveAll(x => !x.CourseName.Contains(search,StringComparison.OrdinalIgnoreCase) &&
                !x.ShortDescription.Contains(search,StringComparison.OrdinalIgnoreCase));
        }

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData data, int id)
    {
        var output = data.Courses.SingleOrDefault(x => x.Id == id);

        if (output is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(output);
    }
}
