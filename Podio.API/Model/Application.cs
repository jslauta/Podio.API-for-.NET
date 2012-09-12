using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Podio.API.Model
{
	[DataContract]
	public class Application 
	{


		[DataMember(Name = "app_id", IsRequired=false)]
		public int AppId { get; set; }


		[DataMember(Name = "original", IsRequired=false)]
		public int Original { get; set; }


		[DataMember(Name = "original_revision", IsRequired=false)]
		public int OriginalRevision { get; set; }


		[DataMember(Name = "status", IsRequired=false)]
		public string Status { get; set; }


		[DataMember(Name = "icon", IsRequired=false)]
		public string Icon { get; set; }


		[DataMember(Name = "icon_id", IsRequired=false)]
		public int IconId { get; set; }


		[DataMember(Name = "space_id", IsRequired=false)]
		public int SpaceId { get; set; }


		[DataMember(Name = "owner_id", IsRequired=false)]
		public int OwnerId { get; set; }


		[DataMember(Name = "owner", IsRequired=false)]
		public Dictionary<string,string> Owner { get; set; }


		[DataMember(Name = "config", IsRequired=false)]
		public Dictionary<string,string> Config { get; set; }


		[DataMember(Name = "fields", IsRequired=false)]
		public string[] Fields { get; set; }


		[DataMember(Name = "subscribed", IsRequired=false)]
		public bool Subscribed { get; set; }


        //[DataMember(Name = "integration", IsRequired=false)]
        //public Dictionary<string,string> Integration { get; set; }


		[DataMember(Name = "rights", IsRequired=false)]
		public string[] Rights { get; set; }


		[DataMember(Name = "link", IsRequired=false)]
		public string Link { get; set; }


		[DataMember(Name = "url_add", IsRequired=false)]
		public string UrlAdd { get; set; }


		[DataMember(Name = "token", IsRequired=false)]
		public string Token { get; set; }


		[DataMember(Name = "url_label", IsRequired=false)]
		public string UrlLabel { get; set; }


		[DataMember(Name = "mailbox", IsRequired=false)]
		public string Mailbox { get; set; }


		[DataMember(Name = "name", IsRequired=false)]
		public string Name { get; set; }


		[DataMember(Name = "item_name", IsRequired=false)]
		public string ItemName { get; set; }


		[DataMember(Name = "integration", IsRequired=false)]
		public Integration Integration { get; set; }


	}
}
