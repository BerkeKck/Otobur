using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class AksesyonDefteri
{
    [Key]
    [Required]
    public string AksesyonNumarasi { get; set; }

    [Required(ErrorMessage = "Bitkinin ad� gereklidir.")]
    [DisplayName("Bitkinin Ad�")]
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
    Canl�Bitki,
    So�an,
    Rizom,
    K�k,
    Tohum,
    �elik,
    Yumru,
    A��,
    Spor,
    Bilinmiyor
}