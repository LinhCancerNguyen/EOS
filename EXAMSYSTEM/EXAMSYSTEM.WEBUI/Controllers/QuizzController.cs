using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.CORE.ModelViews;
using EXAMSYSTEM.SERVICE.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EXAMSYSTEM.WEBUI.Controllers
{
    [Authorize]
    public class QuizzController : Controller
    {
        private readonly IConfiguration config;
        private readonly IUserExamService userExamService;
        private readonly IUserService userService;
        private readonly ISubjectService subjectService;
        private readonly IQuestionService questionService;

        const string SessionUser = "_User";
        const string SessionSubject = "_Subject";
        const string NumberQuestion = "_Number";

        public QuizzController(IConfiguration config, IUserExamService userExamService, IUserService userService, ISubjectService subjectService, IQuestionService questionService)
        {
            this.userExamService = userExamService;
            this.userService = userService;
            this.subjectService = subjectService;
            this.questionService = questionService;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model, string returnUrl)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            if (ModelState.IsValid)
            {
                var user = userService.Login(model.Username, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionUser, user.Username);
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.GivenName, user.Password),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }
                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("SelectSubject", "Quizz");
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("SelectSubject", "Quizz");
            }
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("SelectSubject", "Quizz");
        }

        [Authorize]
        [HttpGet]
        public IActionResult SelectSubject()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            SubjectView subject = new SubjectView();
            if (ViewData["User"] != null)
            {
                subject.ListOfSubject = subjectService.GetAllSubjects();
                return View(subject);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult SelectSubject(SubjectView model)
        {
            Subject SubjectSelected = subjectService.GetSubject(model.SubjectId);
            if (SubjectSelected != null)
            {
                HttpContext.Session.SetString(SessionSubject, SubjectSelected.SubjectName);
                HttpContext.Session.SetString(NumberQuestion, model.NumberOfQuestion.ToString());
                return RedirectToAction("QuizTest");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult QuizTest()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            ViewData["Subject"] = HttpContext.Session.GetString(SessionSubject);

            if (ViewData["Subject"] != null && ViewData["User"] != null && HttpContext.Session.GetString(NumberQuestion) != null)
            {
                int n = int.Parse(HttpContext.Session.GetString(NumberQuestion));
                string subject = (string)HttpContext.Session.GetString(SessionSubject);
                Random rd = new Random();
                int randomSkip = rd.Next(0, 5);
                IEnumerable<Question> questions = questionService.GetQuestionBySubjectName(subject).Skip(randomSkip).Take(n);
                return View(questions);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public void QuizTest(List<AnswerView> yourAnswers)
        {
            List<AnswerView> finalResultQuiz = new List<AnswerView>();
            int right = 0;
            float score = 0;
            foreach (AnswerView answser in yourAnswers)
            {
                AnswerView result = questionService.GetResult(answser);
                finalResultQuiz.Add(result);
                if(result.IsCorrect)
                {
                    right++;
                }
            }
            score = ((float)right / (float)finalResultQuiz.Count) * 10;
            string subject = (string)HttpContext.Session.GetString(SessionSubject);
            string user = (string)HttpContext.Session.GetString(SessionUser);
            User userModel = userService.GetUserByName(user);
            Subject subjectModel = subjectService.GetSubjectByName(subject);
            UserExam userExam = new UserExam {
                Score = score,
                UserId = userModel.UserId,
                SubjectId = subjectModel.SubjectId
            };
            if (ModelState.IsValid)
            {
                userExamService.CreateUserExam(userExam);
            }
        }
    }
}