using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;

namespace CareerCloud.ADODataAccessLayer
{
    public class BaseClass
    {
        protected string DbString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
    }
}
