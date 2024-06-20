using MedRouter.Core.DTOs;
using Microsoft.AspNetCore.Identity;


namespace MedRouter.Core.Entities;

    public class ApplicationUser : IdentityUser
    {
    public string Name { get; set; }
        
        public string Privilege { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }

