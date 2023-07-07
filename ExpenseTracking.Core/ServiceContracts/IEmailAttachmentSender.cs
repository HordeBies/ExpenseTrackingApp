namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IEmailAttachmentSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage, Stream attachmentStream, string attachmentName);
    }
}
