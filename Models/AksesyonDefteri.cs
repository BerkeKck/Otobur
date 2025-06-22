using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class AksesyonDefteri
{
    [Key]
    [Required]
    public string AksesyonNumarasi { get; set; }

    [Required(ErrorMessage = "Bitkinin adý gereklidir.")]
    [DisplayName("Bitkinin Adý")]
    public string BitkininAdi { get; set; }
    public MateryalCesidiEnum MateryalCesidi { get; set; }
    public string Koken { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }

    [DataType(DataType.Date)]
    public DateTime ToplanmaTarihi { get; set; }

    public string ToplayiciAdi { get; set; }
    public string ToplayiciKodu { get; set; }
    public string ToplayiciNumarasi { get; set; }

    // Navigation property
    public HerbaryumDefteri Herbaryum { get; set; }
}

public enum MateryalCesidiEnum
{
    CanlýBitki,
    Soðan,
    Rizom,
    Kök,
    Tohum,
    Çelik,
    Yumru,
    Aþý,
    Spor,
    Bilinmiyor
}