
namespace AppSDK.Managers.UiManager.UiLib
{
    public class Bootstrap : UiBase<Bootstrap> 
    {
        public Bootstrap()
        {
            Myself = this;
        }
        public static Bootstrap Table()
        {
            return New("Table", "table").Id("dasdsa");
        }
        
       
    }
}
