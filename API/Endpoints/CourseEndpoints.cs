using API.Data;

namespace API.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses",(CourseData data) =>
        {
            return data.Courses;
        });

    }
}
