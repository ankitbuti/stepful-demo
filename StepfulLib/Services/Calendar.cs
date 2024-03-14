using MongoDB.Bson;
using MongoDB.Driver;

namespace StepfulLib;

public class TimeSlot
{
    public string Id { get; set; }
    public string PeerUserFullName { get; set; }               // Not Null - If booked
    public string PeerPhone { get; set; }
    public DateTime StartTime { get; set; }

    public TimeSlot(DateTime t)
    {
        Id = ObjectId.GenerateNewId().ToString();
        StartTime = t;
    }

    public DateTime EndTime
    {
        get
        {
            return StartTime.AddHours(2);               // As Per Given Use Case
        }
    }
    
    public bool IsOpen
    {
        get
        {
            return String.IsNullOrEmpty(PeerUserFullName);
        }
    }

    public double Duration {
        get
        {
            return EndTime.Subtract(StartTime).TotalMinutes;
        }
    }
}

public class TimeSample
{
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Text { get; set; }
};
