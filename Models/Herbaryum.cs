using System.ComponentModel.DataAnnotations;

public class Herbaryum
{
    [Key]
    public int HerbaryumNo { get; set; }
    public string BitkininAdi { get; set; }
    public string ToplayiciAdi { get; set; }
    public string ToplayiciKodu { get; set; }
    public string ToplayiciNumarasi { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }

    [Required]
    public string AksesyonNumarasi { get; set; } //Foreign key to AksesyonDefteri
    public string Fotograf { get; set; }

    // Navigation property to AksesyonDefteri
    public Aksesyon Aksesyon { get; set; }
}