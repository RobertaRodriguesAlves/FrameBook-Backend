using System;

namespace Framebook.Domain.Models
{
    public class Profissional
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
    }
}
