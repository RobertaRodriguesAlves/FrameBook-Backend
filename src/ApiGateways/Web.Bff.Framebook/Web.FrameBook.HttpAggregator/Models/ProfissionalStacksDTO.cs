using System.Collections.Generic;

namespace Web.FrameBook.HttpAggregator.Models
{
    internal class ProfissionalStacksDTO
    {
        public ProfissionalDTO profissionalDTO { get; set; }

        public IList<StacksDTO> StacksExperiencia { get; set; }

        public IList<StacksDTO> StacksDesejaAprender { get; set; }

        public ProfissionalStacksDTO()
        {
            StacksExperiencia = new List<StacksDTO>();
            StacksDesejaAprender = new List<StacksDTO>();
        }
    }

}
