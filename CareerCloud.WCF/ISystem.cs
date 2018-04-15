using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISystem" in both code and config file together.
    [ServiceContract]
    public interface ISystem
    {
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] items);
        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode();

        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string Id);

        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] items);

        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] items);

        // System Language Code

        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] items);
        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();

        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id);

        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items);

        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items);
    }
}
