using System;

namespace Framebook.Business.DTO.DTO
{
    public class ProfessionalDTO
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
