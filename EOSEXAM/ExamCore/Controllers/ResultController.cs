using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ExamCore.Models;
using ExamCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamCore.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResult _Result;
        private readonly ISubject _Subject;
        private readonly IUser _User;
        private readonly IResultDetail _ResultDetail;

        public ResultController(IResult _IResult, ISubject _ISubject, IUser _IUser, IResultDetail _IResultDetail)
        {
            _Result = _IResult;
            _Subject = _ISubject;
            _User = _IUser;
            _ResultDetail = _IResultDetail;
        }

        public IActionResult Index()
        {
            dynamic models = new ExpandoObject();
            models.Result = _Result.All;
            models.User = _User.All;
            models.Subject = _Subject.All;
            models.ResultDetail = _ResultDetail.All;
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Result model)
        {
            if (ModelState.IsValid)
            {
                _Result.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var result = _Result.GetResult(Id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Result.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var result = _Result.GetResult(Id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }


        [HttpPost]
        public IActionResult Edit(Result Result)
        {
            if (ModelState.IsValid)
            {
                _Result.Edit(Result);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}