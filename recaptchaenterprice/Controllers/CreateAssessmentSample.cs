using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.RecaptchaEnterprise.V1;

namespace recaptchaenterprice.Controllers
{
    public class CreateAssessmentSample
    {
        // Create an assessment to analyze the risk of a UI action.
        // projectID: Your Google Cloud Project ID.
        // recaptchaKey: The reCAPTCHA key associated with the site/app
        // token: The generated token obtained from the client.
        // recaptchaAction: Action name corresponding to the token.
        public Assessment createAssessment(string projectID = "self-worker-7c92a", string recaptchaKey = "6LflQBgqAAAAABz5tdqlQFQZR2FKiRHu2g1xi5Hg", string token = "action-token", string recaptchaAction = "action-name")
        {
            // Create the reCAPTCHA client.
            // TODO: Cache the client generation code (recommended) or call client.close() before exiting the method.
            RecaptchaEnterpriseServiceClient client = RecaptchaEnterpriseServiceClient.Create();

            ProjectName projectName = new ProjectName(projectID);

            // Build the assessment request.
            CreateAssessmentRequest createAssessmentRequest = new CreateAssessmentRequest()
            {
                Assessment = new Assessment()
                {
                    // Set the properties of the event to be tracked.
                    Event = new Event()
                    {
                        SiteKey = recaptchaKey,
                        Token = token,
                        ExpectedAction = recaptchaAction
                    },
                },
                ParentAsProjectName = projectName
            };

            Assessment response = client.CreateAssessment(createAssessmentRequest);
            return response;

            //// Check if the token is valid.
            //if (response.TokenProperties.Valid == false)
            //{
            //    return "The CreateAssessment call failed because the token was: " +
            //        response.TokenProperties.InvalidReason.ToString();
            //}

            //// Check if the expected action was executed.
            //if (response.TokenProperties.Action != recaptchaAction)
            //{
            //    return "The action attribute in reCAPTCHA tag is: " +
            //        response.TokenProperties.Action.ToString() +
            //        "The action attribute in the reCAPTCHA tag does not \" +\r\n\"match the action you are expecting to score";
            //}

            //// Get the risk score and the reason(s).
            //// For more information on interpreting the assessment, see:
            //// https://cloud.google.com/recaptcha-enterprise/docs/interpret-assessment
            //return "The reCAPTCHA score is: " + ((decimal)response.RiskAnalysis.Score);

            //foreach (RiskAnalysis.Types.ClassificationReason reason in response.RiskAnalysis.Reasons)
            //{
            //    System.Console.WriteLine(reason.ToString());
            //}
        }

        public static void Main(string[] args)
        {
            new CreateAssessmentSample().createAssessment();
        }
    }
}