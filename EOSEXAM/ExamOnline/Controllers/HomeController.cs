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

namespace ExamOnline.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUser _User;
        private readonly ISubject _Subject;
        const string SessionUser = "_User";
        const string SessionSubject = "_Subject";

        public HomeController(IUser _IUser, ISubject _ISubject)
        {
            _User = _IUser;
            _Subject = _ISubject;
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
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToLocal(returnUrl, model);
                }
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
            if(model.RoleId.Equals(1))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("SelectSubject", "Home");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult SelectSubject()
        {
            ViewData["User"] = HttpContext.Session.GetString(SessionUser);
            return View(_Subject.All);
        }

        [HttpPost]
        public ActionResult SelectSubject(Subject model)
        {
            Subject SubjectSelected = _Subject.GetSubject(model.SubjectId);
            if (SubjectSelected != null)
            {
                return RedirectToAction("QuizTest");
            }

            return View();
        }
        /*
        [HttpGet]
        public ActionResult QuizTest()
        {
            IQueryable<Subject> questions = null;

            if (quizSelected != null)
            {
                questions = dbContext.Questions.Where(q => q.Quiz.QuizID == quizSelected.QuizID)
                   .Select(q => new QuestionVM
                   {
                       QuestionID = q.QuestionID,
                       QuestionText = q.QuestionText,
                       Choices = q.Choices.Select(c => new ChoiceVM
                       {
                           ChoiceID = c.ChoiceID,
                           ChoiceText = c.ChoiceText
                       }).ToList()

                   }).AsQueryable();


            }

            return View(questions);
        }

        [HttpPost]
        public ActionResult QuizTest(List<QuizAnswersVM> resultQuiz)
        {
            List<QuizAnswersVM> finalResultQuiz = new List<viewModels.QuizAnswersVM>();

            foreach (QuizAnswersVM answser in resultQuiz)
            {
                QuizAnswersVM result = dbContext.Answers.Where(a => a.QuestionID == answser.QuestionID).Select(a => new QuizAnswersVM
                {
                    QuestionID = a.QuestionID.Value,
                    AnswerQ = a.AnswerText,
                    isCorrect = (answser.AnswerQ.ToLower().Equals(a.AnswerText.ToLower()))

                }).FirstOrDefault();

                finalResultQuiz.Add(result);
            }

            return Json(new { result = finalResultQuiz }, JsonRequestBehavior.AllowGet);
        }
        */
    }
}
