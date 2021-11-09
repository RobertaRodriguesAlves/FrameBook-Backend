using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framebook.Domain.Models
{
    public class StackAprender
    {
        [Key, Column(Order = 1)]
        public Int32 ProfissionalId { get; set; }

        [Key, Column(Order = 2)]
        public Int32 StackId { get; set; }
    }
}
