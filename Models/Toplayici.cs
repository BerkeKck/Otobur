using System.ComponentModel.DataAnnotations;

public class Toplayici
{
    [Key]
    public string ToplayiciKodu { get; set; }
    public string ToplayiciAdi { get; set; }
    public string Telefon { get; set; }
    public string Eposta { get; set; }
}