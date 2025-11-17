namespace Core;

public class Anmodning
{
    public int AnmodningId { get; set; }
    
    public int AnnonceId { get; set; }

    public int BuyerId { get; set; }
    
    public int BrugerId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Status { get; set; } = "pending";

    public DateTime Created { get; set; } = DateTime.UtcNow;
}