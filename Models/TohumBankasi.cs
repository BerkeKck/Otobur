using System.ComponentModel.DataAnnotations;

public class TohumBankasi
{
    [Key]
    public string AksesyonNumarasi { get; set; }
    public string BitkininAdi { get; set; }
    public string Miktar { get; set; }
    public string BulunduguDolap { get; set; }
}