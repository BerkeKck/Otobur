using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Aksesyon
{
    [Key]
    [Required]
    [MaxLength(20)]
    public string AksesyonNumarasi { get; set; }

    [Required(ErrorMessage = "Bitkinin ad� gereklidir.")]
    [DisplayName("Bitkinin Ad�")]
    public string BitkininAdi { get; set; }
    public MateryalCesidiEnum MateryalCesidi { get; set; }
    public string Koken { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ToplanmaTarihi { get; set; }

    public string KullaniciAdi { get; set; }
    public string KullaniciKodu { get; set; }
    public string KullaniciNumarasi { get; set; }

    // Navigation properties
    [BindNever]
    public BitkiDurum BitkiDurum { get; set; }
    [BindNever]
    public TohumBankasi TohumBankasi { get; set; }
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