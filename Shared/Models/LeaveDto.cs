public class LeaveDto
{
    public int UserId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string Reason { get; set; }
}