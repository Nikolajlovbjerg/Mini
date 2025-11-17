namespace Core;

public class Anmodning
{
    public int AnmodningId { get; set; }
    
    public int BrugerId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Status { get; set; }
    
    public string BilledeUrl { get; set; }
}