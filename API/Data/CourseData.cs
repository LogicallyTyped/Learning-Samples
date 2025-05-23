using API.Models;
using System.Text.Json;

namespace API.Data;

public class CourseData
{
    public List<CourseModel> Courses { get; private set; }

    public CourseData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // This will make sure that path will work on any type of machine Windows/Linux/Mac
        string filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Data",
            "sampledata.json");

        string json = File.ReadAllText(filePath);

        Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, options) ?? new();
    }
}
