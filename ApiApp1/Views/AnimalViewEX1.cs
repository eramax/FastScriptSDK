using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiApp1.Views
{
    public class AnimalViewEX1
    {
        public bool Get = false;
        public bool Post = false;
        public bool Put = false;
        public bool Delete = false;

        public void Test()
        {
            Service<Emp>.InvokeAction("List", null);
        }
    }
    public interface ITask
    {
       // object DoTask(object input);
    }

    public interface ITask<T1,T2>
    {
        T1 DoTask(T2 input);
    }
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TAction<T1,T2> : ITask<T1, T2> 
        where T1 : new() 
    {
        public T1 DoTask(T2 input)
        {
            return new T1();
        }
    }
    public class Service<TEntity> where TEntity : new()
    {
        public static Dictionary<string, Func<TEntity , TEntity>> Actions { get; set; }
            = new Dictionary<string, Func<TEntity, TEntity>>();

        public static TEntity InvokeAction(string ActionName, TEntity funcInput)
        {
            if (Actions.ContainsKey(ActionName))
                return Actions[ActionName](funcInput);
            return default(TEntity);
        }
    }
}