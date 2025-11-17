namespace Core;

public class Annonce
{
    public int AnonnceId { get; set; }
    
    public int BrugerId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
    
    public string Category { get; set; }
    
    public string Status { get; set; }
    
    public int SælgerId { get; set; }
    
    public int LocationId { get; set; }
    
    public List<Anmodning> Anmodninger { get; set; }
}