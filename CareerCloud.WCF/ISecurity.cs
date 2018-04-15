using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurity" in both code and config file together.
    [ServiceContract]
    public interface ISecurity
    {
        [OperationContract]
        void AddSecurityLogin(SecurityLoginPoco[] items);
        [OperationContract]
        List<SecurityLoginPoco> GetAllSecurityLogin();

        [OperationContract]
        SecurityLoginPoco GetSingleSecurityLogin(string Id);

        [OperationContract]
        void RemoveSecurityLogin(SecurityLoginPoco[] items);

        [OperationContract]
        void UpdateSecurityLogin(SecurityLoginPoco[] items);

        // Security Login Log

        [OperationContract]
        void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items);
        [OperationContract]
        List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog();

        [OperationContract]
        SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id);

        [OperationContract]
        void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items);

        [OperationContract]
        void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items);

        // Security Login Role

        [OperationContract]
        void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items);
        [OperationContract]
        List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole();

        [OperationContract]
        SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id);

        [OperationContract]
        void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items);

        [OperationContract]
        void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items);

        //Security Role

        [OperationContract]
        void AddSecurityRole(SecurityRolePoco[] items);
        [OperationContract]
        List<SecurityRolePoco> GetAllSecurityRole();

        [OperationContract]
        SecurityRolePoco GetSingleSecurityRole(string Id);

        [OperationContract]
        void RemoveSecurityRole(SecurityRolePoco[] items);

        [OperationContract]
        void UpdateSecurityRole(SecurityRolePoco[] items);

    }
}
