using MedRouter.Core.DTOs;
using MedRouter.Core.Wrappers;

namespace MedRouter.Core.Interfaces;
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        public Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        
    }
