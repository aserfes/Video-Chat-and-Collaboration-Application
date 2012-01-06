using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllSurvey
    {

        private static SurveyDS.SurveyDSDataTable processData(SurveyDS.SurveyDSDataTable dt)
        {
            return dt;
        }



        public static SurveyDS.SurveyDSDataTable GetAllSurveys()
        {
            SurveyDS.SurveyDSDataTable dt = DalSurvey.GetAllSurveys();
            return processData(dt);
        }



        public static SurveyDS.SurveyDSDataTable SelectSurvey(Int32 surveyId)
        {
            SurveyDS.SurveyDSDataTable dt = DalSurvey.SelectSurvey(surveyId);
            return processData(dt);
        }


        public static Int32 InsertSurvey(string surveyName)
        {
            return DalSurvey.InsertSurvey(surveyName);
        }

        public static Int32 UpdateSurvey(Int32 surveyId, string surveyName)
        {
            return DalSurvey.UpdateSurvey(surveyId, surveyName);
        }

        public static Int32 DeleteSurvey(Int32 surveyId)
        {
            return DalSurvey.DeleteSurvey(surveyId);
        }




        //=====================================================================================================================







        private static SurveyDS.SurveyQuestionDSDataTable processData(SurveyDS.SurveyQuestionDSDataTable dt)
        {
            return dt;
        }











        //public static SurveyDS.SurveyQuestionDSDataTable GetSurveyQuestionByFacility(Int32 facilityId)
        //{
        //    SurveyDS.SurveyQuestionDSDataTable dt = DalSurvey.GetSurveyQuestionByFacility(facilityId);
        //    return processData(dt);
        //}
        //public static SurveyDS.SurveyQuestionDSDataTable GetAllSurveyQuestions(Int32 surveyId)
        //{
        //    SurveyDS.SurveyQuestionDSDataTable dt = DalSurvey.GetAllSurveyQuestions(surveyId);
        //    return processData(dt);
        //}
        //public static SurveyDS.SurveyQuestionDSDataTable SelectSurveyQuestion(Int32 surveyQuestionId)
        //{
        //    SurveyDS.SurveyQuestionDSDataTable dt = DalSurvey.SelectSurveyQuestion(surveyQuestionId);
        //    return processData(dt);
        //}
        //public static Int32 InsertSurveyQuestion(Int32 surveyId, Int32 surveyTypeId, string title)
        //{
        //    return DalSurvey.InsertSurveyQuestion(surveyId, surveyTypeId, title);
        //}
        //public static Int32 UpdateSurveyQuestion(Int32 surveyQuestionId, Int32 surveyId, Int32 surveyTypeId, string title)
        //{
        //    return DalSurvey.UpdateSurveyQuestion(surveyQuestionId, surveyId, surveyTypeId, title);
        //}
        //public static Int32 DeleteSurveyQuestion(Int32 surveyQuestionId)
        //{
        //    return DalSurvey.DeleteSurveyQuestion(surveyQuestionId);
        //}




        //=====================================================================================================================





        private static SurveyDS.SurveyResponseDSDataTable processData(SurveyDS.SurveyResponseDSDataTable dt)
        {
            return dt;
        }



        public static SurveyDS.SurveyResponseDSDataTable GetSurveyResponseByIncident(Int32 incidentId)
        {
            SurveyDS.SurveyResponseDSDataTable dt = DalSurvey.GetSurveyResponseByIncident(incidentId);
            return processData(dt);
        }


        public static Int32 InsertSurveyResponse(Int32 incidentId, Int32 surveyId, Int32 questionId, string surveyResponse)
        {
            return DalSurvey.InsertSurveyResponse(incidentId, surveyId, questionId, surveyResponse);
        }



    }



    public class BllSurveyQuestion
    {

        public static SurveyDS.SurveyQuestionDSDataTable GetAllSurveyQuestions(Int32 surveyId)
        {
            return DalSurveyQuestion.GetAllSurveyQuestions(surveyId);
        }

        public static void SetSurveyQuestion(Int32 surveyId, Int32 questionId, bool isSet)
        {
            DalSurveyQuestion.SetSurveyQuestion(surveyId, questionId, isSet);
        }

    }

}
