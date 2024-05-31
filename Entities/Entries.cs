namespace Entities;

public class Entries
{
    public int EntryId { get; set; }
    public int UserId { get; set; }
    public double Principal { get; set; }
    public double Rate { get; set; }
    public int Time { get; set; }
    public double TotalInterest { get; set; }
}