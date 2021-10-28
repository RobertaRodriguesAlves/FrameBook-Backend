using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framebook.Domain.Models
{
    public class Profissional
    {
        [Key]
        public Guid Id_Profissional { get; set; }
        public string Nome { get; set; }
        [Key]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
    }
}
