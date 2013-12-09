using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandOfStartups.Models
{
    public class ViewDataModel
    {
        public int pageID { get; set; }
        //public int userID { get; set; }
       // public int startupID { get; set; }
        public List<Information> pageInformation { get; set; }
        public List<UserAnswer> userAnswers { get; set; }
        public List <QuestionPublicAnswer> publicAnswers { get; set; }
    }

    public class UserAnswer
    {
        public int userID { get; set; }
        public int questionID { get; set; }
        public string question { get; set; }
        [DataType(DataType.MultilineText)]
        public string answer { get; set; }
        public bool isPublic { get; set; }
    }
    
    public class QuestionPublicAnswer
    {
        public string question { get; set; }
        public List<StartupAnswer> answers { get; set; }
    }

    public class StartupAnswer
    {
        /*public string startup { get; set; }
        public string link { get; set; }*/
        public string userName { get; set; }
        public string answer { get; set; }
    }

}