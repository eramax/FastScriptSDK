using ApiApp1.Models;
using AppSDK.Api;
namespace WebApp2.Controllers
{
    public class AnimalsController : SdkApiController<Animal, DContext>
    {
    }
}