namespace SurveySystem.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public int RespondentID { get; set; }
        public int QuestionID { get; set; }

        public virtual Respondent Respondent { get; set; }
        public virtual Question Question { get; set; }
    }
}