using System;
using System.ComponentModel.DataAnnotations;

public class BitkiDurum
{
    [Key]
    public int Id { get; set; }
    public string AksesyonNumarasi { get; set; }
    public string BitkininAdi { get; set; }
    public DateTime GozlemTarihi { get; set; }
    public string BahcedeBulunduguYer { get; set; }
    public string YerKodu { get; set; }
    public string BitkininDurumu { get; set; }
    public string VejetasyonDurumu { get; set; }
    public string Gozlem { get; set; }
}