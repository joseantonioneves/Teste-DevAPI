public class Transfer
{
    public int Id { get; set; }
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public virtual User FromUser { get; set; }
    public virtual User ToUser { get; set; }
}