using System;

namespace imperugo.corsi.flashmobile.services.Repositories.Documents
{
	public class Chat : DocumentBase<string>
	{
		public string[] CallerIdentifiers { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string AvatarFileName { get; set; }
	}
}