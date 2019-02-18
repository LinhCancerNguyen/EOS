using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetQuestion(int Id);
        void CreateCategory(Category category);
        void SaveCategory();
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }

    public class CategoryService : ICategoryService
    {
        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetQuestion(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
