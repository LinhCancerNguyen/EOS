using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamOnline.Models;
using ExamOnline.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Linq;
using ExamOnline.ModelsView;
using System;

namespace ExamOnline.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUser _User;
        private readonly ISubject _Subject;
        private readonly IQuestion _Question;
        private readonly IAnswer _Answer;
        const string SessionUser = "_User";
        const string SessionSubject = "_Subject";
        const string NumberQuestion = "_Number";

        public HomeController(IUser _IUser, ISubject _ISubject, IQuestion _IQuestion, IAnswer _IAnswer)
        {
            _User = _IUser;
            _Subject = _ISubject;
            _Question = _IQuestion;
            _Answer = _IAnswer;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _User.Login(model.UserName, model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString(SessionUser, user.UserName);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.GivenName, user.Password),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToLocal(returnUrl, model);
                }
                else
                {
                    ViewBag.ErrorLogin = "Tên đăng nhập hoặc tài khoản không chính xác";
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Admin", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl, User model)
        {
                return RedirectToAction("SelectSubject", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult SelectSubject()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            SubjectVM subject = new SubjectVM();
            if (ViewData["User"] != null)
            {
                subject.ListOfSubject = _Subject.GetAll();
                return View(subject);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [Authorize]
        [HttpPost]
        public ActionResult SelectSubject(SubjectVM model)
        {
            Subject SubjectSelected = _Subject.GetSubject(model.SubjectId);
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
                Random rd = new Random();
                int randomSkip = rd.Next(0, 3);
                IQueryable<Question> questions = _Question.GetQuestionBySubjectName(HttpContext.Session.GetString(SessionSubject)).Skip(randomSkip).Take(n);
                return View(questions);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult QuizTest(List<QuizAnswerVM> resultQuiz)
        {
            List<QuizAnswerVM> finalResultQuiz = new List<QuizAnswerVM>();

            foreach (QuizAnswerVM answser in resultQuiz)
            {
                QuizAnswerVM result = _Answer.GetAnswerByYourAnswer(answser);
                finalResultQuiz.Add(result);
            }

            return Json(new { result = finalResultQuiz });
        }

    }
}
