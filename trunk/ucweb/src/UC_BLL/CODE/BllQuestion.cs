using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllQuestion
    {

        private static QuestionDS.QuestionDSDataTable processData(QuestionDS.QuestionDSDataTable dt)
        {
            return dt;
        }








        //=====================================================================================================================

        public static QuestionDS.QuestionDSDataTable GetAllQuestions()
        {
            QuestionDS.QuestionDSDataTable dt = DalQuestion.GetAllQuestions();
            return processData(dt);
        }

        public static QuestionDS.QuestionDSDataTable GetQuestionsBySurvey(Int32 surveyId)
        {
            QuestionDS.QuestionDSDataTable dt = DalQuestion.GetQuestionsBySurvey(surveyId);
            return processData(dt);
        }



        public static QuestionDS.QuestionDSDataTable SelectQuestion(Int32 questionId)
        {
            QuestionDS.QuestionDSDataTable dt = DalQuestion.SelectQuestion(questionId);
            return processData(dt);
        }


        public static Int32 InsertQuestion(Int32 typeId, string text)
        {
            return DalQuestion.InsertQuestion(typeId, text);
        }

        public static Int32 UpdateQuestion(Int32 questionId, Int32 typeId, string text)
        {
            return DalQuestion.UpdateQuestion(questionId, typeId, text);
        }

        public static Int32 DeleteQuestion(Int32 questionId)
        {
            return DalQuestion.DeleteQuestion(questionId);
        }




        //=====================================================================================================================






    }
}
