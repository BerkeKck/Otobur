using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BitkiDurum
{
    [Key, ForeignKey("Aksesyon")]
    public string AksesyonNumarasi { get; set; } // Hem PK hem FK

    // Sadece bitki durumuna özel alanlar:
    public DateTime GozlemTarihi { get; set; }
    public string BahcedeBulunduguYer { get; set; }
    public string YerKodu { get; set; }
    public string BitkininDurumu { get; set; }
    public string VejetasyonDurumu { get; set; }
    public string Gozlem { get; set; }

    // Navigation property
    public Aksesyon Aksesyon { get; set; }
}