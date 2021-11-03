using System;

namespace Framebook.Domain.Models
{
    public class Professional
    {
        public Guid ProfessionalId { get; set; }    
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCadastro { get; set; }       
    }
}
