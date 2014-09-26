using Innovix.Base.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Innovix.Base.Data.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> Listar();
        IQueryable<T> Listar<T1, T2, T3>(Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2, Expression<Func<T, T3>> incluirPropriedade3);
        IQueryable<T> Listar<T1, T2>(Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2);
        IQueryable<T> Listar<TProperty>(Expression<Func<T, TProperty>> incluirPropriedade);

        T ObterPorId(int id);

        //C[R]UD
        IQueryable<T> Pesquisar(Expression<Func<T, bool>> predicate);

        //C[R]UD
        IQueryable<T> Pesquisar<T1>(Expression<Func<T, bool>> predicate, Expression<Func<T, T1>> incluirPropriedade);

        //Não é possível fazer um array de expressões Expression<Func<T, object>>, pois o raciocínio de polimorfismo não vale quando o assunto é análise de expressões lambda. O framework de persistência
        //só vai identificar uma propriedade se seu tipo exato estiver estaticamente definido na expressão.
        //O próprio .Net Framework tem alguns métodos no System.Linq que têm diversas sobrecargas com T1, T2, T3... Tn por esta razão.

        //C[R]UD
        IQueryable<T> Pesquisar<T1, T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2);

        //CR[U]D
        void Salvar(T entidade);

        //CRU[D]
        void Apagar(T entidade);
    }
}