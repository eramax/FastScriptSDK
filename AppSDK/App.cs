using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace AppSDK
{
    public class Loger : ILoger
    {
        public void log(string message)
        {
            Console.WriteLine("Loger: " + message);
        }
    }
    public class Config : IConfig
    {
        public ILoger getLoger()
        {
            return new Loger();
        }

        public IUserManager getUserManager()
        {
            throw new NotImplementedException();
        }

        public string getDbConnectionString()
        {
            //return @"Data Source=.\SQLEXPRESS;Initial Catalog=AppDb;Integrated Security=True;";
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=sdk1;Integrated Security=SSPI;
                    User ID=admin;Password=123;";
        }
    } 
}
