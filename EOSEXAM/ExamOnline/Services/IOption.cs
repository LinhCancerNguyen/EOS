using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Services
{
    public interface IOption
    {
        IEnumerable<Option> GetAll();
        Option GetOption(int? Id);
        void Add(Option _Option);
        void Remove(int? Id);
        void Edit(Option _Option);
    }
}
