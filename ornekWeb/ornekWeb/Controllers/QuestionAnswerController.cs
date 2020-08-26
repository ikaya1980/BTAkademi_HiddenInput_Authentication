using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ornekWeb.Models;
using ornekWeb.Data;

namespace ornekWeb.Controllers
{
    public class QuestionAnswerController : Controller
    {
        private readonly IEntityData<QuestionAnswer> questionAnswerData;

        public QuestionAnswerController(IEntityData<QuestionAnswer> questionAnswerData)
        {
            this.questionAnswerData = questionAnswerData;
        }
        // GET: QuestionAnswerController
        public ActionResult Index()
        {
            return View(questionAnswerData.GetAll());
        }

        public ActionResult Details(int id)
        {
            QuestionAnswer questionAnswer = questionAnswerData.GetById(id);
            if (questionAnswer != null)
                return View(questionAnswerData.GetById(id));
            else
                return NotFound();
        }

        public ActionResult Create(int id)
        {
            //Ekran inputlarının dolu gelmesi için, model dolu gönderilmesi gerekiyor. 
            QuestionAnswer questionAnswer = new QuestionAnswer()
            {
                firmId = id
            };

            return View(questionAnswer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAnswer questionAnswer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionAnswerData.Insert(questionAnswer);
                    questionAnswerData.Commit();

                    return RedirectToAction(nameof(Index));
                }

                return View(questionAnswer);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            QuestionAnswer questionAnswer = questionAnswerData.GetById(id);
            if (questionAnswer != null)
                return View(questionAnswer);
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAnswer questionAnswer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questionAnswerData.Update(questionAnswer);
                    questionAnswerData.Commit();

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(questionAnswer);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                questionAnswerData.Delete(id);
                questionAnswerData.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
