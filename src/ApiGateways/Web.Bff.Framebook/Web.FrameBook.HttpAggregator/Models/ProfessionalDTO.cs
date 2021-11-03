using System;

namespace Web.FrameBook.HttpAggregator.Models
{
    internal class ProfessionalDTO
    {
        public Guid ProfessionalId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }
    }
}
