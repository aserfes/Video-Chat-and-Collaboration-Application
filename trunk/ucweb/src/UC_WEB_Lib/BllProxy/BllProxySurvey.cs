using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxySurvey
    {




        public static SurveyDS.SurveyDSDataTable GetAllSurveys()
        {
            return BllSurvey.GetAllSurveys();
        }



        public static SurveyDS.SurveyDSDataTable SelectSurvey(Int32 survey_id)
        {
            return BllSurvey.SelectSurvey(survey_id);
        }


        public static Int32 InsertSurvey(string survey_name)
        {
            return BllSurvey.InsertSurvey(survey_name);
        }

        public static Int32 UpdateSurvey(Int32 survey_id, string survey_name)
        {
            return BllSurvey.UpdateSurvey(survey_id, survey_name);
        }

        public static Int32 DeleteSurvey(Int32 survey_id)
        {
            return BllSurvey.DeleteSurvey(survey_id);
        }









        //public static SurveyDS.SurveyDSDataTable SelectSurvey(Int32 survey_id)
        //{
        //    return BllSurvey.SelectSurvey(survey_id);
        //}

        //===============================






        //public static SurveyDS.SurveyQuestionDSDataTable GetSurveyQuestionByFacility(Int32 facility_id)
        //{
        //    return BllSurvey.GetSurveyQuestionByFacility(facility_id);
        //}
        //public static SurveyDS.SurveyQuestionDSDataTable GetAllSurveyQuestions(Int32 survey_id)
        //{
        //    return BllSurvey.GetAllSurveyQuestions(survey_id);
        //}
        //public static SurveyDS.SurveyQuestionDSDataTable SelectSurveyQuestion(Int32 survey_question_id)
        //{
        //    return BllSurvey.SelectSurveyQuestion(survey_question_id);
        //}
        //public static Int32 InsertSurveyQuestion(Int32 survey_id, Int32 survey_type_id, string title)
        //{
        //    return BllSurvey.InsertSurveyQuestion(survey_id, survey_type_id, title);
        //}
        //public static Int32 UpdateSurveyQuestion(Int32 survey_question_id, Int32 survey_id, Int32 survey_type_id, string title)
        //{
        //    return BllSurvey.UpdateSurveyQuestion(survey_question_id, survey_id, survey_type_id, title);
        //}
        //public static Int32 DeleteSurveyQuestion(Int32 survey_question_id)
        //{
        //    return BllSurvey.DeleteSurveyQuestion(survey_question_id);
        //}







        //===============================






        public static SurveyDS.SurveyResponseDSDataTable GetSurveyResponseByIncident(Int32 incidentId)
        {
            return BllSurvey.GetSurveyResponseByIncident(incidentId);
        }



        public static Int32 InsertSurveyResponse(Int32 incident_id, Int32 survey_id, Int32 question_id, string survey_response)
        {
            return BllSurvey.InsertSurveyResponse(incident_id, survey_id, question_id, survey_response);
        }

    }




    public class BllProxySurveyQuestion
    {

        public static SurveyDS.SurveyQuestionDSDataTable GetAllSurveyQuestions(Int32 survey_id)
        {
            return BllSurveyQuestion.GetAllSurveyQuestions(survey_id);
        }

        public static void SetSurveyQuestion(Int32 survey_id, Int32 question_id, bool is_set)
        {
            BllSurveyQuestion.SetSurveyQuestion(survey_id, question_id, is_set);
        }

    }


}
