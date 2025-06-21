using System;
using System.ComponentModel.DataAnnotations;

public class AksesyonDefteri
{
    [Key]
    public string AksesyonNumarasi { get; set; }
    public string BitkininAdi { get; set; }
    public MateryalCesidiEnum MateryalCesidi { get; set; }
    public string Koken { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }
    public DateTime ToplanmaTarihi { get; set; }
    public string ToplayiciAdi { get; set; }
    public string ToplayiciKodu { get; set; }
    public string ToplayiciNumarasi { get; set; }
}

public enum MateryalCesidiEnum
{
    CanliBitki,
    Tohum,
    Celik,
    Sogan
}