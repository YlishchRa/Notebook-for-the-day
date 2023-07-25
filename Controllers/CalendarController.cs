using Microsoft.AspNetCore.Mvc;

namespace CalendarASP.Net.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult CalendarView()
        {
            return View();
        }
    }
}
