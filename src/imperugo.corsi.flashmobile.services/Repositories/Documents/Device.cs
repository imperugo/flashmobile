namespace imperugo.corsi.flashmobile.services.Repositories.Documents
{
	public class Device : DocumentBase<string>
	{
		public string CallerIdentifier { get; set; }
		public string DeviceIdentifier { get; set; }
	}
}