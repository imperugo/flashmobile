namespace imperugo.corsi.flashmobile.services.Repositories.Documents
{
	public abstract class MessageBase : DocumentBase<string>
	{
		public bool Read { get; set; }
		public string Text { get; set; }
		public string ChatIdentifier { get; set; }
	}

	public abstract class MediaMessageBase : MessageBase
	{
		public string MediaFileName { get; set; }
	}

	public class TextMessage : MessageBase { }
	public class ImageMessage : MediaMessageBase { }
	public class VideoMessage : MediaMessageBase { }
	public class AudioMessage : MediaMessageBase { }

	public class ContactMessage : MediaMessageBase
	{
		public string Firsname { get; set; }
		public string Lastname { get; set; }
	}

	public class LocationMessage : MessageBase
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}