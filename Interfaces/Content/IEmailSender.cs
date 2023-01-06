using DomainModel.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Content
{
     public interface IEmailSender
    {
       void SendEmailAsync(Callback callback,IFormFile formFile);
    }
}
