using System.ComponentModel.DataAnnotations;

namespace BancoDigital.Api.Models
{
    public class ContaModel
    {
        [Key]
        [Required]
        [MinLength(1)]
        public int Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
