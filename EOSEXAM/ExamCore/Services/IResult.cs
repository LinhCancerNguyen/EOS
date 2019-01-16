using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface IResult
    {
        IEnumerable<Result> All { get; }
        Result GetResult(int? Id);
        void Add(Result _Result);
        void Remove(int? Id);
        void Edit(Result _Result);
    }
}
