using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imperugo.corsi.flashmobile.services.APIs
{
	[Authorize]
	[Route("api/[controller]/[action]")]
	public class MessagesController : ControllerBase
	{
	}
}