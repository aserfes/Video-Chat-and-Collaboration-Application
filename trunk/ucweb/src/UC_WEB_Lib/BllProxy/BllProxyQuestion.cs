using System;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyQuestion
    {




        public static QuestionDS.QuestionDSDataTable GetAllQuestions()
        {
            return BllQuestion.GetAllQuestions();
        }

        public static QuestionDS.QuestionDSDataTable GetQuestionsBySurvey(Int32 survey_id)
        {
            return BllQuestion.GetQuestionsBySurvey(survey_id);
        }





        public static QuestionDS.QuestionDSDataTable SelectQuestion(Int32 question_id)
        {
            return BllQuestion.SelectQuestion(question_id);
        }


        public static Int32 InsertQuestion(Int32 type_id, string question_text)
        {
            return BllQuestion.InsertQuestion(type_id, question_text);
        }

        public static Int32 UpdateQuestion(Int32 question_id, Int32 type_id, string question_text)
        {
            return BllQuestion.UpdateQuestion(question_id, type_id, question_text);
        }

        public static Int32 DeleteQuestion(Int32 question_id)
        {
            return BllQuestion.DeleteQuestion(question_id);
        }





        //===============================


    }


}
