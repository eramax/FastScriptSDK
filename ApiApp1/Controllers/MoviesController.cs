using ApiApp1.Models;
using AppSDK.Api;
using System.Web.Http.Cors;

namespace ApiApp1.Controllers
{
    public class MoviesController : SdkApiController<Movie,DContext>
    {

    }
}