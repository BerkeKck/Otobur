using System.ComponentModel.DataAnnotations;

public class Herbaryum
{
    [Key]
    public int HerbaryumNo { get; set; }
    public string BitkininAdi { get; set; }
    public string KullaniciAdi { get; set; }
    public string KullaniciKodu { get; set; }
    public string KullaniciNumarasi { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }

    [Required]
    public string AksesyonNumarasi { get; set; } //Foreign key to AksesyonDefteri
    public string Fotograf { get; set; }

    // Navigation property to AksesyonDefteri
    public Aksesyon Aksesyon { get; set; }
}