namespace Domain.Entities;

public class RequestLog
{
    public long Id { get; set; }

    public string Method { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Path { get; set; }

    public int StatusCode { get; set; }
}
