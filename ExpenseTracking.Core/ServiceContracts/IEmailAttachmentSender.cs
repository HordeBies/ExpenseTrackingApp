using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IEmailAttachmentSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage, Stream attachmentStream, string attachmentName);
    }
}
