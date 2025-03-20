using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASC.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        // Các bộ điều khiển kế thừa từ BaseController sẽ yêu cầu đăng nhập
    }
}
