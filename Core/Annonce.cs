using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core;

//Klasse der representerer en annonce i systemet. Bruges som model til MongoDB.
public class Annonce
{
    //Markerer AnonnceId som det primære nøglefelt i MongoDB
    [BsonId]
    public int AnonnceId { get; set; }

    //BrugerId refererer til den bruger, der har oprettet annoncen
    public int BrugerId { get; set; }

    //Titel på annoncen
    public string? Title { get; set; }

    //Beskrivelse af annoncen
    public string? Description { get; set; }

    //Pris for varen i annoncen
    public double Price { get; set; }

    //Kategori for annoncen
    public string? Category { get; set; }

    //Status for annoncen (f.eks. aktiv, solgt)
    public string? Status { get; set; }

    //URL til billede af varen i annoncen
    public string? ImageUrl { get; set; }

    //Id på sælgeren af varen i annoncen
    public int SælgerId { get; set; }

    //Lokation for varen i annoncen, Så man ved hvor den befinder sig
    public string? Location { get; set; }

    //Liste over anmodninger relateret til annoncen
    public List<Anmodning>? Anmodninger { get; set; }
}