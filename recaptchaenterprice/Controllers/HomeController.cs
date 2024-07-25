using Google.Cloud.RecaptchaEnterprise.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace recaptchaenterprice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SubmitContact()
        {
            string response = Request.Form["recaptchaToken"];
            CreateAssessmentSample createAssessmentSample = new CreateAssessmentSample();
            var assessment = createAssessmentSample.createAssessment("self-worker-7c92a", "6LflQBgqAAAAABz5tdqlQFQZR2FKiRHu2g1xi5Hg", response, "contact_form");

            if (!assessment.TokenProperties.Valid || assessment.RiskAnalysis.Score < 0.5)
            {
                ModelState.AddModelError(string.Empty, "Invalid reCAPTCHA");
                return View();
            }

            string success = "test";
            return View();
        }
    }
}