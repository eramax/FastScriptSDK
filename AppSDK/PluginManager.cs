using AppSDK.mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace AppSDK
{
    public static class PluginManager
    {
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

        private static Dictionary<string, Type> ControllersTypes = new Dictionary<string, Type>();
        private static Dictionary<string, string> ViewsPath = new Dictionary<string, string>();
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
                            string controller_namespace = t.Namespace.Substring(0, t.Namespace.IndexOf("."));
                            ViewsPath.Add(controller_name, "~/plugins/" + controller_namespace + "/Views");
                        }
                        else if (t.IsSubclassOf(typeof(ApiController)))
                        {
                            ApiController con = Activator.CreateInstance(t) as ApiController;
                            ControllersTypes.Add(controller_name, con.GetType());
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
        public static IController GetController(string controllerName)
        {
            return GetNewObject(GetControllerType(controllerName)) as IController;
        }
        public static ApiController GetApiController(string controllerName)
        {
            return GetNewObject(GetControllerType(controllerName , true)) as ApiController;
        }
        public static string GetControllerViews(string controllerName)
        {
            return ViewsPath[controllerName];
        }
    }
}
