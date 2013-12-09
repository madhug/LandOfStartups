using LandOfStartups.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace LandOfStartups.Controllers
{
    public class PagesController : Controller
    {
        private LandOfStartupsContext db = new LandOfStartupsContext();

        public ActionResult growth()
        {
            //db = new LandOfStartupsContext();
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            //db.

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;                       

            dm.pageID = (from p in db.Pages
                         where p.name == "Growth"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Growth"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;
                ua.userID = currentUser;
                List<Answer> ansQuery = db.Answers.ToList();
                ua.answer = (from a in db.Answers
                             where a.userID == currentUser && a.questionID == pageQuestions[i].questionID
                             select a.text).FirstOrDefault();
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);
        }

        public ActionResult fundraising()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Fundraising"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Fundraising"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult team()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Team"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Team"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult planning()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            // dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Planning"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Planning"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult technologies()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Technologies"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Technologies"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult marketing()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Marketing"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Marketing"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult legalities()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            //dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Legalities"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Legalities"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        public ActionResult intro()
        {
            //db = new LandOfStartupsContext();
            MembershipUser user = Membership.GetUser(User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int currentUser = (int)user.ProviderUserKey;
            Session["currentUser"] = currentUser;

            ViewDataModel dm = new Models.ViewDataModel();

            // dm.userID = currentUser;

            dm.pageID = (from p in db.Pages
                         where p.name == "Introduction"
                         select p.pageID).FirstOrDefault();

            var posts = from p in db.Information
                        where p.page.name == "Introduction"
                        select p;

            var questions = from q in db.Questions
                            where q.pageID == dm.pageID
                            select q;

            List<Question> pageQuestions = questions.ToList();
            dm.publicAnswers = new List<Models.QuestionPublicAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                QuestionPublicAnswer qpa = new QuestionPublicAnswer();
                qpa.question = pageQuestions[i].text;
                qpa.answers = new List<Models.StartupAnswer>();
                if (pageQuestions[i].answers != null)
                {
                    foreach (Answer ans in pageQuestions[i].answers)
                    {
                        if (ans.isPublic == true)
                        {
                            StartupAnswer sa = new Models.StartupAnswer();
                            sa.answer = ans.text;
                            sa.userName = User.Identity.Name;
                            qpa.answers.Add(sa);
                        }
                    }
                }
                else
                {
                    StartupAnswer sa = new Models.StartupAnswer();
                    sa.answer = "No one has answered yet. Be the first one to answer!";
                    sa.userName = User.Identity.Name;
                    qpa.answers.Add(sa);
                }
                dm.publicAnswers.Add(qpa);
            }

            dm.userAnswers = new List<Models.UserAnswer>();
            for (int i = 0; i < pageQuestions.Count; i++)
            {
                UserAnswer ua = new UserAnswer();
                ua.isPublic = true;

                ua.questionID = pageQuestions[i].questionID;
                ua.question = pageQuestions[i].text;

                /*ua.answer = (from a in db.Answer
                                where a.userID == dm.userID && a.questionID == pageQuestions[i].questionID
                                select a.text).FirstOrDefault();*/
                dm.userAnswers.Add(ua);
            }
            dm.pageInformation = posts.ToList();
            return View(dm);

        }

        //
        // GET: /Pages/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Pages/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pages/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pages/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pages/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pages/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pages/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pages/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
