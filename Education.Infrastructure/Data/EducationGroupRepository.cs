using Education.Domain;
using Education.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Education.Infrastructure.Data
{
    public class EducationGroupRepository : IEducationGroupRepository
    {
        protected readonly EducationDbContext context;
        public EducationGroupRepository(EducationDbContext context)
        {
            this.context = context;
        }
        public async Task Add(tb_EducationGroup entity)
        {
             context.EducationGroup.AddAsync(entity);
        }

        public Task<tb_EducationGroup?> GetById(int id)
        {
            var educationGroup = context.EducationGroup.Include(i => i.Educations).FirstOrDefault(i => i.EducationGroupId == id);
            return Task.FromResult(educationGroup);
        }

        public Task<List<tb_EducationGroup>> GetList(Expression<Func<tb_EducationGroup, bool>> predicate = null)
        {
            var list = context.EducationGroup.Include(i => i.Educations).ToList();
            return Task.FromResult(list);
        }

        public async Task Update(tb_EducationGroup entity)
        {
            context.EducationGroup.Update(entity);
        }
    }
}
