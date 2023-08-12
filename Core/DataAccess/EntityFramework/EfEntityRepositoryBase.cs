using Core.Entities;
using Core.Utilities.Result.DataResult;
using Core.Utilities.Result.VoidResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity> where Tentity : class, IEntity, new() where Tcontext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            using (Tcontext context)
            {

            }
        }

        public void Delete(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Tentity entity)
        {
            throw new NotImplementedException();
        }
    }
}
