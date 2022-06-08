using Microsoft.AspNetCore.Mvc;

namespace DddStore.WebApp.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("5914573c-5635-435a-a4a7-f2a626f31698");
    }
}
