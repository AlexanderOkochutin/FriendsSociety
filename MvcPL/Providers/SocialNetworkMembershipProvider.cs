using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using ICryptoService;
using MvcPL.ViewModels;

namespace MvcPL.Providers
{
    /// <summary>
    ///  class - custom mewmbership provider
    /// </summary>
    public class SocialNetworkMembershipProvider : MembershipProvider
    {
        public IPasswordService PasswordService
         => (IPasswordService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IPasswordService));

        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public IProfileService ProfileService
            => (IProfileService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IProfileService));

        /// <summary>
        /// Method for creating new user
        /// </summary>
        /// <param name="viewModel">model from registration form</param>
        /// <returns>membership user wich was created</returns>
        public MembershipUser CreateUser(RegistrationViewModel viewModel)
        {
            MembershipUser membershipUser = GetUser(viewModel.Email, false);

            if (membershipUser != null)
            {
                return null;
            }

            var salt = PasswordService.GetSalt();
            var user = new BllUser
            {
                Email = viewModel.Email,
                PasswordSalt = salt,
                MailSalt = PasswordService.GetSalt(),
                Password = PasswordService.GetHash(viewModel.Password, salt),
                IsEmailConfirmed = false,
                Roles = new List<string>() { "User" }
            };

            UserService.AddUser(user);
            var userProfile = ProfileService.GetByUserEmail(viewModel.Email);
            userProfile.BirthDay = viewModel.Birthday;
            userProfile.FirstName = viewModel.FirstName;
            userProfile.LastName = viewModel.LastName;
            ProfileService.Update(userProfile);
            membershipUser = GetUser(viewModel.Email, false);
            return membershipUser;
        }

        /// <summary>
        /// Verify input password and mail of user 
        /// </summary>
        public override bool ValidateUser(string email, string password)
        {
            var user = UserService.GetUserByEmail(email);

            if (user != null && PasswordService.VerifyPassword(password, user.PasswordSalt, user.Password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method for getting user by email
        /// </summary>
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            var user = UserService.GetUserByEmail(email);

            if (user == null) return null;

            var memberUser = new MembershipUser("SocialNetworkMembershipProvider", user.Email,
                null, null, null, null,
                false, false, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue);

            return memberUser;
        }

        #region Stabs
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion     
    }
}