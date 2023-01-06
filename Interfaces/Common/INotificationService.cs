using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Common
{
    public interface INotificationService
    {
        Task<bool> SendEmailAsync(string emailTo, string message, string subject);
    }
}
