using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.SurveyDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalSurvey
    {

        public static SurveyDS.SurveyDSDataTable GetAllSurveys()
        {
            SurveyDSTableAdapter ta = new SurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllSurveys();
        }






        public static SurveyDS.SurveyDSDataTable SelectSurvey(Int32 surveyId)
        {
            SurveyDSTableAdapter ta = new SurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(surveyId);
        }





        public static Int32 InsertSurvey(string surveyName)
        {
            SurveyDSTableAdapter ta = new SurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return Convert.ToInt32(ta.InsertSurvey(surveyName));
        }

        public static Int32 UpdateSurvey(Int32 surveyId, string surveyName)
        {
            SurveyDSTableAdapter ta = new SurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Update(surveyId, surveyName);
        }

        public static Int32 DeleteSurvey(Int32 surveyId)
        {
            SurveyDSTableAdapter ta = new SurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(surveyId);
        }

        //========================











        //========================











        public static SurveyDS.SurveyResponseDSDataTable GetSurveyResponseByIncident(Int32 incidentId)
        {
            SurveyResponseDSTableAdapter ta = new SurveyResponseDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetSurveyResponseByIncident(incidentId);
        }

        public static Int32 InsertSurveyResponse(Int32 incidentId, Int32 surveyId, Int32 questionId, string surveyResponse)
        {
            SurveyResponseDSTableAdapter ta = new SurveyResponseDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            int id = Convert.ToInt32(ta.InsertSurveyResponse(incidentId, surveyId, questionId, surveyResponse));
            return id;
        }



    }




    public class DalSurveyQuestion
    {

        public static SurveyDS.SurveyQuestionDSDataTable GetAllSurveyQuestions(Int32 surveyId)
        {
            SurveyQuestionDSTableAdapter ta = new SurveyQuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(surveyId);
        }

        public static void SetSurveyQuestion(Int32 surveyId, Int32 questionId, bool isSet)
        {
            SurveyQuestionDSTableAdapter ta = new SurveyQuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetSurveyQuestion(surveyId, questionId, isSet);
        }

    }

}
