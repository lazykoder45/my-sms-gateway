using Microsoft.Extensions.Configuration;
using MySmsGateway.Dao;
using MySmsGateway.Entity;
using MySmsGateway.Entity.VM;
using MySmsGateway.Services.Exceptions;
using MySmsGateway.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Services
{
    public class UserService
    {
        public const string REGISTRATION_VERIFY_EMAIL_SUBJECT = "Please verify you email to access the services.";
        private readonly UserDao dao;
        private readonly PasswordHelper passwordHelper;
        private readonly NotificationService notificationService;
        private readonly IConfiguration configuration;
        private readonly string appBaseUrl;
        public UserService(UserDao dao
            , PasswordHelper passwordHelper
            , NotificationService notificationService
            , IConfiguration configuration)
        {
            this.dao = dao;
            this.passwordHelper = passwordHelper;
            this.notificationService = notificationService;
            this.configuration = configuration;
            this.appBaseUrl = configuration["AppConfig:BaseUrl"];
        }

        public bool Register(RegisterVm model)
        {
            // check if email is allready registered & verified
            var userInfo = dao.GetByEmailId(model.Email);
            if (userInfo != null)
            {
                if (!userInfo.IsEmailVerified)
                {
                    throw new RegistrationException(RegistrationException.VERIFY_EMAIL);
                }

                throw new RegistrationException(RegistrationException.ALLREADY_REGISTERED);
            }

            // create a new entry in the db
            userInfo = new UserInfo();
            userInfo.Name = model.Name;
            userInfo.Email = model.Email;
            userInfo.PasswordHash = passwordHelper.SecurePassword(model.Password);
            userInfo.CreateAt = DateTime.UtcNow;
            userInfo.IsEmailVerified = false;
            userInfo.VerificationTokenExpiry = DateTime.UtcNow.AddDays(1);
            userInfo.VerificationToken = Guid.NewGuid();
            var success = dao.InsertNewUserInfo(userInfo);
            if (!success)
            {
               // throw generic exception
            }
            var html = GetRegistartionVerificationEmailFromTemplate(userInfo);
            notificationService.SendEmail(REGISTRATION_VERIFY_EMAIL_SUBJECT, html, userInfo.Email, userInfo.Name).Wait();
            return true;
        }

        private string GetRegistartionVerificationEmailFromTemplate(UserInfo userInfo)
        {
            var verificationUrl = $"{appBaseUrl}/email-verify?t={userInfo.VerificationToken.ToString()}&u={userInfo.Email}";
            var htmlTemplate = Helper.ReadResourceAsString(this.GetType().Assembly, "MySmsGateway.Services.Templates.Emails.RegistartionVerifyEmail.html");
            htmlTemplate = htmlTemplate.Replace("__NAME__", userInfo.Name);
            htmlTemplate = htmlTemplate.Replace("__LINK_EXPIRY_TEXT__", "24 hours");
            htmlTemplate = htmlTemplate.Replace("__VERIFICATION_URL__", verificationUrl);
            return htmlTemplate;
        }
    }
}
