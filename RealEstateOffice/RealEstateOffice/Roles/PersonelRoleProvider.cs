using RealEstateOffice.Models;
using System;
using System.Linq;
using System.Web.Security;

namespace RealEstateOffice.Roles
{
    public class PersonelRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            dbContext c = new dbContext();
            string agentRole = string.Empty;
            string adminRole = string.Empty;

            var user = c.Admins.Where(a => a.admin_username == username).FirstOrDefault();

            if (user != null)
            {
                adminRole = user.role;
            }

            var admin = c.Agents.Where(a => a.agent_username == username).FirstOrDefault();

            if (admin != null)
            {
                agentRole = admin.role;
            }

            string[] result = { agentRole, adminRole };
            return result;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}