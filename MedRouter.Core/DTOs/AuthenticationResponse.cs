using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedRouter.Core.DTOs;

    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        
        public string JWToken { get; set; }
        public string RefreshToken { get; set; }
    }

