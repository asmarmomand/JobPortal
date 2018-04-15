using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.EntityFrameworkDataAccess;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in both code and config file together.
    public class Security : ISecurity
    {
        //add record
        public void AddSecurityLogin(SecurityLoginPoco[] items)
        {
            var reference = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            reference.Add(items);
        }

        //add record
        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var reference = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            reference.Add(items);
        }

        //add record
        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var reference = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            reference.Add(items);
        }

        //add record
        public void AddSecurityRole(SecurityRolePoco[] items)
        {
            var reference = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            reference.Add(items);
        }

        // return multiple record
        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            var reference = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return reference.GetAll();
        }

        // return multiple record
        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            var reference = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
           return reference.GetAll();
        }

        // return multiple record
        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            var reference = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
           return reference.GetAll();
        }

        // return multiple record
        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            var reference = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return reference.GetAll();
        }

        // return single record
        public SecurityLoginPoco GetSingleSecurityLogin(string Id)
        {
            var reference = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        // return single record
        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
        {
            var reference = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        // return single record
        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
        {
            var reference = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        // return single record
        public SecurityRolePoco GetSingleSecurityRole(string Id)
        {
            var reference = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        // remove  record
        public void RemoveSecurityLogin(SecurityLoginPoco[] items)
        {
            var reference = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
             reference.Delete(items);
        }

        // remove  record
        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var reference = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            reference.Delete(items);
        }

        // remove record
        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var reference = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            reference.Delete(items);
        }

        // remove record
        public void RemoveSecurityRole(SecurityRolePoco[] items)
        {
            var reference = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            reference.Delete(items);
        }

        // update record
        public void UpdateSecurityLogin(SecurityLoginPoco[] items)
        {
            var reference = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            reference.Update(items);
        }

        // update record
        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
        {
            var reference = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            reference.Update(items);
        }

        // update record
        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
        {
            var reference = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            reference.Update(items);
        }

        // update record
        public void UpdateSecurityRole(SecurityRolePoco[] items)
        {
            var reference = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
            reference.Update(items);
        }
    }
}
