using System;
using System.Collections;

namespace Framebook.Business.DTO.DTO
{
    public class PerfilDTO
    {
        public Guid PerfilId { get; set; }
        public ProfessionalDTO Profissional { get; set; }
        public StackDTO Stacks { get; set; }
    }
}
