using System.ComponentModel.DataAnnotations;

public class HerbaryumDefteri
{
    [Key]
    public int HerbaryumNo { get; set; }
    public string BitkininAdi { get; set; }
    public string ToplayiciAdi { get; set; }
    public string ToplayiciKodu { get; set; }
    public string ToplayiciNumarasi { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }
    public string AksesyonNumarasi { get; set; }
    public string Fotograf { get; set; }
}