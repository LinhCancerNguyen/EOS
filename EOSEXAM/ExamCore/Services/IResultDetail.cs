using ExamCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCore.Services
{
    public interface IResultDetail
    {
        IEnumerable<ResultDetail> All { get; }
        ResultDetail GetResultDetail(int? Id);
        void Add(ResultDetail _ResultDetail);
        void Remove(int? Id);
        void Edit(ResultDetail _ResultDetail);
    }
}
