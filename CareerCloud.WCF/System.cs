using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    class System : ISystem
    {
        // System Country Code
        public void AddSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var reference = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            reference.Add(items);
        }

        // System language Code
        public void AddSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var reference = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            reference.Add(items);
        }

        // retun single 
        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            var reference = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return reference.GetAll();
        }

        // return multiple records
        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            var reference = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return reference.GetAll();
        }

        // return single 
        public SystemCountryCodePoco GetSingleSystemCountryCode(string Id)
        {
            var reference = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            return reference.Get(Id);
        }

        //return single
        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id)
        {
            var reference = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            return reference.Get(Id);
        }

        //remove single 
        public void RemoveSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var reference = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            reference.Delete(items);
        }

        //remove single record
        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var reference = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            reference.Delete(items);
        }

        // update record
        public void UpdateSystemCountryCode(SystemCountryCodePoco[] items)
        {
            var reference = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            reference.Update(items);
        }

        //update record
        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items)
        {
            var reference = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
            reference.Update(items);
        }
    }
}
