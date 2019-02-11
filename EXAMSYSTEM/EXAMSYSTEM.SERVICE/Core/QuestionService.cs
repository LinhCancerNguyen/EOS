﻿using EXAMSYSTEM.CORE.Models;
using EXAMSYSTEM.INFRA.Infrastructure;
using EXAMSYSTEM.INFRA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EXAMSYSTEM.SERVICE.Core
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int Id);
        void CreateQuestion(Question question);
        void SaveQuestion();
        void Update(Question question);
        void Delete(Question question);
    }

    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateQuestion(Question question)
        {
            questionRepository.Add(question);
            SaveQuestion();
        }

        public void Delete(Question question)
        {
            questionRepository.Delete(question);
            SaveQuestion();
        }

        public Question GetQuestion(int Id)
        {
            return questionRepository.GetDetailById(Id);
        }

        public IEnumerable<Question> GetQuestions()
        {
            return questionRepository.GetQuestions().OrderByDescending(q => q.QuestionId);
        }

        public void SaveQuestion()
        {
            unitOfWork.Commit();
        }

        public void Update(Question question)
        {
            questionRepository.Edit(question);
            SaveQuestion();
        }
    }
}