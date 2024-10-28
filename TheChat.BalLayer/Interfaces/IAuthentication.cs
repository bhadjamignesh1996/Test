using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChat.ServerModel;
using static TheChat.BalLayer.ViewModels.AuthenticationViewModel;

namespace TheChat.BalLayer.Interfaces
{
    public interface IAuthentication
    {
        Task<string> Registration(RegistrationViewModel RVM);

        Task<string> UserUpdateStatus(string userId);

        Task<AuthenticationResponseViewModel> SignIn(AuthenticationRequestViewModel ARVM);

        Task<string> ForgotPassword(string emailId);

        Task<string> ResetPassword(ResetPasswordViewModel RPVM);

        Task<string> ChangePassword(ChangePasswordViewModel CPVM);

        Task<string> UserActivate(string emailId);

        Task<string> VerifyCode(VerifyUserViewModel VUVM);

        Task<AuthDetailsDisplayViewModel> UpsertAuthDetails(AuthDetailsViewModel ADVM);

        Task<AuthDetailsDisplayViewModel> GetAuthDetails();

        Task<AuthDetailsDisplayViewModel> UploadProfileImage(ProfileImageViewModel PIVM);

        Task<AuthDetailsDisplayViewModel> DeleteProfileImage();
    }
}
