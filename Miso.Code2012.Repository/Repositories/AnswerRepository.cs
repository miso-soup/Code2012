using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Miso.Code2012.Model.Answers;
using Newtonsoft.Json;

namespace Miso.Code2012.Repository.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public IEnumerable<Answer> FindAll()
        {
            var url = @"http://code-survey.herokuapp.com/surveys.json";

            var clinet = new WebClient();
            String response = clinet.DownloadString(new Uri(url));

            IEnumerable<Answer> answerList = JsonConvert.DeserializeObject<List<Answer>>(response);

            return answerList;
        }
    }
}
