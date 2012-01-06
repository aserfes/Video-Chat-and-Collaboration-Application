using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.QuestionDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalQuestion
    {

        public static QuestionDS.QuestionDSDataTable GetAllQuestions()
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllQuestions();
        }


        public static QuestionDS.QuestionDSDataTable GetQuestionsBySurvey(Int32 surveyId)
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetQuestionsBySurvey(surveyId);
        }





        public static QuestionDS.QuestionDSDataTable SelectQuestion(Int32 questionId)
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(questionId);
        }

        public static Int32 InsertQuestion(Int32 typeId, string text)
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return Convert.ToInt32(ta.InsertQuestion(typeId, text));
        }

        public static Int32 UpdateQuestion(Int32 questionId, Int32 typeId, string text)
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Update(questionId, typeId, text);
        }

        public static Int32 DeleteQuestion(Int32 questionId)
        {
            QuestionDSTableAdapter ta = new QuestionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(questionId);
        }


        //========================




    }
}
