using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framebook.Domain.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Expires { get; set; }
   
        [NotMapped]
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReplaceByToken { get; set; }
        [NotMapped]
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
