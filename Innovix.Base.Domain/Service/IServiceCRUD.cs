using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Innovix.Base.Domain.Service
{
    public interface IServiceCRUD<TEntity>
     where TEntity : Innovix.Base.Domain.Entity.EntityBase
    {
        void Excluir(int id);

        IEnumerable<TEntity> Listar();
        IEnumerable<TEntity> Listar<T1, T2, T3>(Expression<Func<TEntity, T1>> incluirPropriedade, Expression<Func<TEntity, T2>> incluirPropriedade2, Expression<Func<TEntity, T3>> incluirPropriedade3);
        IEnumerable<TEntity> Listar<T1, T2>(Expression<Func<TEntity, T1>> incluirPropriedade, Expression<Func<TEntity, T2>> incluirPropriedade2);
        IEnumerable<TEntity> Listar<TProperty>(Expression<Func<TEntity, TProperty>> incluirPropriedade);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> Pesquisar(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> Pagination(Expression<Func<TEntity, bool>> where, int limit, int offset);

        void Salvar(TEntity entidade);

        void ExcluirEntidade(TEntity entidade);
    }
}