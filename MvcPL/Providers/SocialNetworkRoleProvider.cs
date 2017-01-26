using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface.Services;

namespace MvcPL.Providers
{
    public class SocialNetworkRoleProvider : RoleProvider
    {
        public IUserService UserService
            => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public override bool IsUserInRole(string email, string roleName)
        {

            var user = UserService.GetUserByEmail(email);

            if (user == null) return false;
            var userRole = user.Roles.FirstOrDefault(r => r == roleName);
            if (userRole != null)
            {
                return true;
            }
            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            var roles = new string[] { };
            var user = UserService.GetUserByEmail(email);
            if (user == null) return roles;
            var userRole = user.Roles;

            if (userRole != null)
            {
                roles = userRole.Select(r => r).ToArray();
            }
            return roles;
        }

        #region stabs

        public override void CreateRole(string roleName)
        {

            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion
    }
}