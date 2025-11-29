namespace WASD.QLicPlatform.API.Reports.Domain.Model.Aggregates;

public class Report
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Report(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length < 4)
            throw new ArgumentException("Title must be at least 4 characters.");
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        Title = title;
        Description = description;
        CreatedAt = DateTime.UtcNow; 
        UpdatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
}