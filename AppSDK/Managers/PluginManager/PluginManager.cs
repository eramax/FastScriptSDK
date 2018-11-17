using AppSDK.Api;
using AppSDK.interfaces;
using AppSDK.mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace AppSDK.Managers.PluginManager
{
    public static class PluginManager
    {
        private static Dictionary<string, Type> ControllersTypes = new Dictionary<string, Type>();
        private static Dictionary<string, IGetNew> TypesObjects = new Dictionary<string, IGetNew>();
        private static Dictionary<string, string> ViewsPath = new Dictionary<string, string>();

        public static object GetNewObject(Type t)
        {
            try
            {
                return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
            }
            catch
            {
                return null;
            }
        }

        public static T GetNew<T>(string controller_name) where T : IGetNew
        {
            return (T) TypesObjects[controller_name].GetNew();
        }


        public static bool LoadLocalControllers()
        {
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var c = LoadAsm(a);
                }catch(Exception ex) { var c = ex.Message; }
            }
            return true;
        }

        public static bool LoadAsm(Assembly a)
        {
            try
            {
                foreach (Type t in a.GetTypes())
                {
                    if (!t.GetTypeInfo().IsAbstract)
                    {
                        string controller_name = t.Name.ToLower();
                        if (t.IsSubclassOf(typeof(Controller)))
                        {
                            Controller con = Activator.CreateInstance(t) as Controller;
                            ControllersTypes.Add(controller_name, con.GetType());
                            TypesObjects.Add(controller_name, con as IGetNew);
                            string controller_namespace = t.Namespace.Substring(0, t.Namespace.IndexOf("."));
                            ViewsPath.Add(controller_name, "~/plugins/" + controller_namespace + "/Views");
                        }
                        else if (t.IsSubclassOf(typeof(ApiController)))
                        {
                            ApiController con = Activator.CreateInstance(t) as ApiController;
                            ControllersTypes.Add(controller_name, con.GetType());
                            TypesObjects.Add(controller_name, con as IGetNew);
                        }
                    }
                }
            }
            catch (Exception ex) { var e = ex.Message;return false; }
            return true;
        }

        public static bool LoadPlugin(string dllFile)
        {
            var asm = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + dllFile);
            return LoadAsm(asm);
        }
        public static Type GetControllerType(string controllerName, bool isApi = false)
        {
            Type controllerType;
            controllerName = controllerName.ToLower();
            if (ControllersTypes.ContainsKey(controllerName + "controller"))
            {
                controllerType = ControllersTypes[controllerName + "controller"];
            }
            else
            {
                if(!isApi) controllerType = typeof(ErrorController);
                else controllerType = typeof(ErrorApiController);
            }
            return controllerType;
        }
        public static Controller GetMVCControllerNew(string controllerName)
        {
            controllerName = controllerName.ToLower();
            if (TypesObjects.ContainsKey(controllerName + "controller"))
            {
                return TypesObjects[controllerName + "controller"].GetNew() as Controller;
            }
            return null;
        }
        public static ApiController GetApiControllerNew(string controllerName)
        {
            controllerName = controllerName.ToLower();
            if (TypesObjects.ContainsKey(controllerName + "controller"))
            {
                return TypesObjects[controllerName + "controller"].GetNew() as ApiController;
            }
            return null;
        }
        public static IController GetController(string controllerName)
        {
            // return GetNewObject(GetControllerType(controllerName)) as IController;
            return GetMVCControllerNew(controllerName);
        }
        public static ApiController GetApiController(string controllerName)
        {
            //return GetNewObject(GetControllerType(controllerName , true)) as ApiController;
            return GetApiControllerNew(controllerName);
        }
        public static string GetControllerViews(string controllerName)
        {
            return ViewsPath[controllerName];
        }
    }
}
