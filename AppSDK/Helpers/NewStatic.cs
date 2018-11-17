using AppSDK.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.Helpers
{
    public class NewStatic<T> where T : IGetNew , new()
    {
        public static T Create()
        {
            return new T();
        }
    }
}
