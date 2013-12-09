using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LandOfStartups.Models
{
    /*public class Startup
    {
        [Key]
        public int startupID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string link { get; set; }

        public virtual ICollection<Answer> answers { get; set; }
    }*/

    public class Information
    {
        [Key]
        public int informationID { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public List<string> references { get; set; }
        public virtual int pageID { get; set; }
        public virtual Page page { get; set; }
    }

    public class Page
    {
        [Key]
        public int pageID { get; set; }
        public string name { get; set; }

        public virtual ICollection<Information> information { get; set; }
        public virtual ICollection<Question> questions { get; set; }
    }

    public class Question
    {
        [Key]
        public int questionID { get; set; }
        public string  text { get; set; }
        public virtual Page page { get; set; }
        public virtual int pageID { get; set; }
        public ICollection<Answer> answers { get; set; }
    }

    public class Answer
    {
        [Key]
        public int answerID { get; set; }
        public string text { get; set; }
        public bool isPublic { get; set; }
        public int userID { get; set; }
        public virtual Question question { get; set; }
        public virtual int questionID { get; set; }
    }
}