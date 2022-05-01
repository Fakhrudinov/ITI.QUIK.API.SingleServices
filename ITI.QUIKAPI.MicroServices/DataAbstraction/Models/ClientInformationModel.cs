using System.ComponentModel;

namespace DataAbstraction.Models
{
    public class ClientInformationModel
    {
		[DefaultValue("Иванов")]
		public string LastName { get; set; }
		[DefaultValue("Иван")]
		public string FirstName { get; set; }
		[DefaultValue("Семенович")]
		public string MiddleName { get; set; }
		[DefaultValue("iii@aaa.ru")]
		public string EMail { get; set; }
	}

	/*
     	<UserInfo>
			<FirstName>**FirstName**</FirstName>
			<MiddleName>**MiddleName**</MiddleName>
			<LastName>**LastName**</LastName>
			<Comment>**Comment**</Comment> // собирать самому
		</UserInfo>
		<ContactInfo>
			<EMail>**EMail**</EMail>
		</ContactInfo>
	*/
}
