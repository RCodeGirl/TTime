using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Content;

namespace Interfaces.Content
{
   public  interface IQuestionService
   {
       Question GetById(int id);
       List<Question> GetAll();
       Question Add(Question model);
       Question Update(Question model);
       bool Delete(int id);

   }
}
