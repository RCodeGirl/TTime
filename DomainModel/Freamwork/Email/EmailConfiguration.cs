namespace DomainModel.Framework.Email
{
    public class EmailConfiguration: IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string UserNameFrom { get; set; }
        public string AddressFrom { get; set; }
        public string PasswordRecoverySubject { get; set; }
        public string RegistrationSubject { get; set; }
        public string Subject { get; set; }
    }
}
