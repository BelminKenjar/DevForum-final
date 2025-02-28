namespace DevForum.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string HtmlMessage);
    }
}
