namespace CSL.Models.Accounts
{
    public class EmailTemplate
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public int? EmailTempCodeID { get; set; }
        public string Text { get; set; }
        public string MobileText { get; set; }
        public string Name { get; set; }
        public int ModuleID { get; set; }
        

    }
}
