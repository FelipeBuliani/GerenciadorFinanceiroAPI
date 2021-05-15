using GerenciadorFinanceiroDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiroDAL.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly Context _context;

        public RepositorioGenerico(Context context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Insert(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                var registro = _context.Set<TEntity>().Update(entity);
                registro.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
