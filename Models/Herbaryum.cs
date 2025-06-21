using System.ComponentModel.DataAnnotations;

public class Herbaryum
{
    [Key]
    public int HerbaryumNo { get; set; }
    public string BitkininAdi { get; set; }
    public string ToplayiciAdi { get; set; }
    public string ToplayiciKodu { get; set; }
    public string ToplayiciNo { get; set; }
    public string Lokasyon { get; set; }
    public string Koordinat { get; set; }
    public string AksesyonNo { get; set; }
    public bool Fotograf { get; set; }
}