namespace DomainModel.Framework.Email
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
        string UserNameFrom { get; set; }
        string AddressFrom { get; set; }
        string PasswordRecoverySubject { get; set; }
        string RegistrationSubject { get; set; }
        string Subject { get; set; }
    }
}
