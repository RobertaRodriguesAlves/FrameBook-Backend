using System;

namespace Framebook.Business.DTO.DTO
{
    public class ProfissionalDTO
    {
        public Guid Id_Profissional { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }    
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
    }
}
