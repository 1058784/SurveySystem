using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveySystem.DAL;
using SurveySystem.ViewModels;

namespace SurveySystem.Controllers
{
    public class HomeController : Controller
    {
        private SurveyContext db = new SurveyContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<SurveyRespondents> data = from survey in db.Surveys
                                                   group survey by survey.Title into surveyGroup
                                                   select new SurveyRespondents()
                                                   {
                                                       Title = surveyGroup.Key,
                                                       RespondentCount = 0 //surveyGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}