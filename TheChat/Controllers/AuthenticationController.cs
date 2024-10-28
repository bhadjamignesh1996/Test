using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChat.BalLayer.Interfaces;
using static TheChat.Utility.Enums.CommonEnum;
using TheChat.Utility.Common;
using static TheChat.BalLayer.ViewModels.AuthenticationViewModel;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace TheChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication authenticationService;

        public AuthenticationController(IAuthentication _authenticationService)
        {
            authenticationService = _authenticationService;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(RegistrationViewModel RVM)
        {

            try
            {
                await authenticationService.Registration(RVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.RegisterSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpGet]
        [Route("UserActiveAccount/{uId}")]
        public async Task<IActionResult> UserActiveAccount(string uId)
        {
            try
            {
                var userStatus = await this.authenticationService.UserUpdateStatus(uId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, userStatus);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthenticationRequestViewModel ARVM)
        {

            try
            {

                AuthenticationResponseViewModel authenticationResponseViewModel = await authenticationService.SignIn(ARVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(authenticationResponseViewModel, Message.GetSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }


        [HttpGet]
        [Route("ForgotPassword/{emailId}")]
        public async Task<IActionResult> ForgotPassword(string emailId)
        {
            try
            {
                await authenticationService.ForgotPassword(emailId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.MailSentSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPut]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel RPVM)
        {

            try
            {
                await authenticationService.ResetPassword(RPVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.PasswordUpdatedSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }


        [HttpGet]
        [Route("UserActivation/{emailId}")]
        public async Task<IActionResult> UserActivation(string emailId)
        {
            try
            {
                await authenticationService.UserActivate(emailId);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.MailSentSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }


        [HttpPut]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel CPVM)
        {

            try
            {
                await authenticationService.ChangePassword(CPVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.PasswordUpdatedSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPut]
        [Route("VerifyUserCodeByEmail")]
        public async Task<IActionResult> VerifyUserCodeByEmail(VerifyUserViewModel VUVM)
        {
            try
            {
                await authenticationService.VerifyCode(VUVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(null, Message.VerifyCodeMatch);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("UpsertAuthDetails")]
        public async Task<IActionResult> UpsertAuthDetails(AuthDetailsViewModel ADVM)
        {
            try
            {
                var AuthDetails = await authenticationService.UpsertAuthDetails(ADVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(AuthDetails, Message.SavedSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("GetAuthDetails")]
        public async Task<IActionResult> GetAuthDetails()
        {
            try
            {
                var AuthDetails = await authenticationService.GetAuthDetails();

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(AuthDetails, Message.GetSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("UploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage([FromForm] ProfileImageViewModel PIVM)
        {
            try
            {
                var authDetails = await authenticationService.UploadProfileImage(PIVM);

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(authDetails, Message.SavedSuccessfully);

                return await Task.FromResult(Ok(objHelper));
            }
            catch (Exception ex)
            {
                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }

        [HttpDelete]
        [ServiceFilter(typeof(ActionFilters.TokenVerify))]
        [Route("DeleteProfileImage")]
        public async Task<IActionResult> DeleteProfileImage()
        {
            try
            {
                var AuthDetails = await authenticationService.DeleteProfileImage();

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForSuccess(AuthDetails, Message.DeletedSuccessfully);

                return await Task.FromResult(Ok(objHelper));

            }
            catch (Exception ex)
            {

                ResponseHelper objHelper = SetResponseHelper.SetRequestResponseForError(ex);

                return StatusCode(objHelper.Status, objHelper);
            }
        }
    }
}
