using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Miso.Code2012.Model.Answers;

namespace Miso.Code2012.UI.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        
        private IAnswerRepository _answerRepository;

        /// <summary>
        /// 回答一覧
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AnswerList()
        {
            return View();
        }

        /// <summary>
        /// JsonResultでとってみるテスト
        /// </summary>
        /// <returns></returns>
        public ActionResult AnserListByJsonResult()
        {
            var answers = _answerRepository.FindAll();

            return Json(answers, JsonRequestBehavior.AllowGet);
        }
    }
}