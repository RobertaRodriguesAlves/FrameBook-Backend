using System.Collections.Generic;

namespace Web.FrameBook.HttpAggregator.Models
{
    internal class ProfessionalStacksDTO
    {
        public ProfessionalDTO ProfessionalDTO { get; set; }

        public IList<StacksDTO> StacksExperiencia { get; set; }

        public IList<StacksDTO> StacksDesejaAprender { get; set; }

        public ProfessionalStacksDTO()
        {
            StacksExperiencia = new List<StacksDTO>();
            StacksDesejaAprender = new List<StacksDTO>();
        }
    }

}
