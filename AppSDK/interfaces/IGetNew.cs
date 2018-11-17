using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSDK.interfaces
{
    public interface IGetNew
    {
        object GetNew();
    }
    public interface IGetNew<T> : IGetNew
    {
        new T GetNew();
    }

}
