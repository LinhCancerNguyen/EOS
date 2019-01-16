using ExamCore.Models;
using ExamCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Repositories
{
    public class OptionRepository : IOption
    {
        public IEnumerable<Option> All => throw new NotImplementedException();

        public void Add(Option _Option)
        {
            throw new NotImplementedException();
        }

        public void Edit(Option _Option)
        {
            throw new NotImplementedException();
        }

        public Option GetOption(int? Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
