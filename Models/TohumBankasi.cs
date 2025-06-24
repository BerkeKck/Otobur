using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TohumBankasi
{
    [Key, ForeignKey("Aksesyon")]
    public string AksesyonNumarasi { get; set; } // Hem PK hem FK

    // Sadece tohum bankasýna özel alanlar:
    public string Miktar { get; set; }
    public string BulunduguDolap { get; set; }

    // Navigation property
    public Aksesyon Aksesyon { get; set; }
}