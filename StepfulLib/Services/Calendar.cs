namespace StepfulLib;

public class TimeSlot
{
    public string Id { get; set; }
    public string StudentId { get; set; }               // If booked by student
    public DateTime StartTime { get; set; }

    public TimeSlot(DateTime t)
    {
        StartTime = t;
    }

    public DateTime EndTime
    {
        get
        {
            return StartTime.AddHours(2);               // As Per Use Case
        }
    }
    
    public bool IsOpen
    {
        get
        {
            return !String.IsNullOrEmpty(StudentId);
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
