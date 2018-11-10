namespace AppSDK
{
    public interface ILoger
    {
        void log(string message);
    }
    public interface IUser
    {
        int getUserId();
        string getUserName();
    }
    public interface IUserManager
    {
        IUser getUser();
    }
    public interface IConfig
    {
        ILoger getLoger();
        IUserManager getUserManager();
        string getDbConnectionString();
    }
    public interface IPlugin
    {
        string pluginName();
        void run();
        void load(IConfig conf);
        void unload();
    }
}
