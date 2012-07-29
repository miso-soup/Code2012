using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Miso.Code2012.Model.Answers;
namespace Miso.Code2012.UI.Web.Mvc.Controllers.Api
{
    /// <summary>
    /// 回答APIコントローラ
    /// </summary>
    public class AnswerController : ApiController
    {
        public AnswerController(
            IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        private IAnswerRepository _answerRepository;

        /// <summary>
        /// すべての回答を取得します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Answer> Get()
        {
            var answers = 
                _answerRepository
                    .FindAll()
                    .OrderByDescending(e => e.CreationDate)
                    .ToList();

            return answers;
        }
    }
}
