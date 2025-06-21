using System.ComponentModel.DataAnnotations;

public class Kullanici
{
    [Key]
    public string KullaniciAdi { get; set; }
    public string Parola { get; set; }
    public string GorebilecegiTablolar { get; set; }
    public string KayitYapabilecegiTablolar { get; set; }
    public bool KayitSilebilme { get; set; }
    public string KullaniciGrubu { get; set; }
}