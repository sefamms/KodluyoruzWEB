using KodluyoruzWEB.Models;
using KodluyoruzWEB.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodluyoruzWEB.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,IUserService userService,
            IEmailService emailService,IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._userService = userService;
            this._emailService = emailService;
            this._configuration = configuration;
            this._roleManager = roleManager;
    }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            { 
                firstName=userModel.firstName,
                lastName=userModel.lastName,
                Email=userModel.email,
                UserName=userModel.email
            };

           var result= await _userManager.CreateAsync(user, userModel.password);
            if (result.Succeeded)
            {
               await GenerateEmailConfirmationTokenAsync(user);

            }

            return result;
        }

        public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }

        }
        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }

        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
         var result= await  _signInManager.PasswordSignInAsync(signInModel.email, signInModel.password, signInModel.rememberMe, true);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        } 

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.currentPassword, model.newPassword);

        }

        public async Task<IdentityResult> ConfirmEmailAsync(string uid,string token)
        {

           return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid),token);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {

         return await  _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId),model.Token,model.NewPassword);
        }


        public async Task SendEmailConfirmationEmail(ApplicationUser user,string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                toEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}",user.firstName),
                     new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+confirmationLink,user.Id,token))
                }
            };
            await _emailService.SendEmailForEmailConfirmation(options);
        }

        public async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                toEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}",user.firstName),
                     new KeyValuePair<string, string>("{{Link}}",string.Format(appDomain+confirmationLink,user.Id,token))
                }
            };
            await _emailService.SendEmailForForgotPassword(options);
        }

    }



}
