namespace CSL.Models.Accounts
{
    public class EmailSetting : BaseModel
    {
        public string EmailUserName { get; set; }
       public string EmailHost { get; set; }
       public int EmailPort { get; set; }
       public string EmailPassword { get; set; }
       public bool EnableSSLForEmail { get; set; }
       public string EmailFromAddress { get; set; }
       public string EmailSenderName { get; set; }
    }
}
