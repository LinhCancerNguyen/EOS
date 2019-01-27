using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Models;

namespace ExamOnline.Services
{
    public interface IRole
    {
        IEnumerable<Role> All { get; }
    }
}
