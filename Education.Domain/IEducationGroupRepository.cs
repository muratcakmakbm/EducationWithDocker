using Education.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Education.Domain
{
    public interface IEducationGroupRepository
    {
        Task<tb_EducationGroup?> GetById(int id);
        Task<List<tb_EducationGroup>> GetList(Expression<Func<tb_EducationGroup, bool>> predicate=null);
        Task Add(tb_EducationGroup entity);
        Task Update(tb_EducationGroup entity);
       
    }
}
