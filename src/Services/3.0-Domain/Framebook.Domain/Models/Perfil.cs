using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framebook.Domain.Models
{
    public class Perfil
    {
        public Guid PerfilId { get; set; }
        public Professional Profissional { get; set; }
        public Stack Stacks { get; set; }
       
    }


}
