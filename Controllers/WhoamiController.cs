using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace AAAuth.Controllers
{
    public class WhoamiResponse
    {
        public string Id { get; set; }
        public string TenantId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
    }

    [Authorize("Denied")]
    [ApiController]
    [Route("[controller]")]
    public class WhoamiController : ControllerBase
    {
        [HttpGet]
        public WhoamiResponse Get()
        {
            return new WhoamiResponse
            {
                Id = User.GetObjectId(),
                TenantId = User.GetTenantId(),
                DisplayName = User.GetDisplayName(),
                Name = User.FindFirstValue(ClaimConstants.Name),
            };
        }
    }
}
