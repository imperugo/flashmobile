using System.Linq;
using imperugo.corsi.flashmobile.services.Results;
using Microsoft.AspNetCore.Mvc;

namespace imperugo.corsi.flashmobile.services.APIs
{
	public class ApiControllerBase : Controller
	{
		public IActionResult Conflict()
		{
			return new ConflictResult();
		}

		public IActionResult Conflict(object error)
		{
			return new ConflictResultObjectResult(error);
		}

		public IActionResult NotAcceptable()
		{
			return new NotAcceptableResult();
		}

		public IActionResult NotAcceptable(object error)
		{
			return new NotAcceptableResultObjectResult(error);
		}

		public string CallerIdentifier => Request.Headers["CallerIdentifier"].FirstOrDefault();
		public string DeviceIdentifier => Request.Headers["DeviceIdentifier"].FirstOrDefault();
	}
}