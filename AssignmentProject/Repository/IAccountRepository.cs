using AssignmentProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AssignmentProject.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(RegisterModel userModel);
        Task<SignInResult> PasswordSignIn(LoginModel loginModel);
        Task SignOutAsync();
        
    }
}