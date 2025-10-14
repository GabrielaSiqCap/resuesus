using Microsoft.AspNetCore.Identity;

namespace resuesus.Models
{
    public class Perfil
    {
        public Guid PerfilId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Senha { get; set; }
        // vincular o perfil a Indentiidade de Login
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

    }
}
