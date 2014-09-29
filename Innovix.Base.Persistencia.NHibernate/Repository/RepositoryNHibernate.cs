using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Expressions;
using Innovix.Base.Domain.Entity;
using Innovix.Base.Data.Repository;

namespace Innovix.Base.Persistencia.NHibernate.Repository
{
    public abstract class RepositoryNHibernate<T> : IRepository<T>
       where T : EntityBase
    {
        protected ISession Session { get; set; }

        //A ISession é injetada pelo container no momento em que ele cria o objeto. Em caso de dúvidas, consulte o bootstrapper da aplicação.
        public RepositoryNHibernate(ISession session)
        {
            this.Session = session;
        }

        public virtual T ObterPorId(int id)
        {
            var entidade = Session.Get<T>(id);
            return entidade;
        }

        public virtual IQueryable<T> Pagination(System.Linq.Expressions.Expression<Func<T, bool>> predicado, int limit, int offset)
        {
            return Session.Query<T>().Where(predicado).Take(offset).Skip(limit);
        }

        public virtual IQueryable<T> Pesquisar(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return Session.Query<T>().Where(predicado);
        }

        public virtual IQueryable<T> Listar()
        {
            return Session.Query<T>();
        }

        public virtual void Salvar(T entidade)
        {
            entidade.ValidarSalvar();

            if (EstaAtualizando(entidade))
            {
                Session.Update(Session.Merge<T>(entidade));
            }
            else
            {
                Session.Save(entidade);
            }
        }

        private static bool EstaAtualizando(T entidade)
        {
            return entidade.Id > 0;
        }

        public virtual void Apagar(int id)
        {
            var entidade = ObterPorId(id);
            entidade.ValidarExclusao();
            Session.Delete(entidade);
        }

        public virtual void Apagar(T entidade)
        {
            entidade.ValidarExclusao();
            Session.Delete(entidade);
        }

        public IQueryable<T> Listar<TProperty>(Expression<Func<T, TProperty>> incluirPropriedade)
        {
            ValidarExpressaoLambda(incluirPropriedade);
            return Session.Query<T>().Fetch(incluirPropriedade);
        }

        public IQueryable<T> Listar<T1, T2>(Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2)
        {
            ValidarExpressaoLambda(incluirPropriedade);
            ValidarExpressaoLambda(incluirPropriedade2);
            return Session.Query<T>().Fetch(incluirPropriedade);
        }

        public IQueryable<T> Listar<T1, T2, T3>(Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2, Expression<Func<T, T3>> incluirPropriedade3)
        {
            ValidarExpressaoLambda(incluirPropriedade);
            ValidarExpressaoLambda(incluirPropriedade2);
            ValidarExpressaoLambda(incluirPropriedade3);
            return Session.Query<T>().Fetch(incluirPropriedade).Fetch(incluirPropriedade2).Fetch(incluirPropriedade3);
        }

        public IQueryable<T> Pesquisar<T1>(Expression<Func<T, bool>> predicate, Expression<Func<T, T1>> incluirPropriedade)
        {
            return Session.Query<T>().Where(predicate).Fetch(incluirPropriedade);
        }

        public IQueryable<T> Pesquisar<T1, T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T1>> incluirPropriedade, Expression<Func<T, T2>> incluirPropriedade2)
        {
            return Session.Query<T>().Where(predicate).Fetch(incluirPropriedade2);
        }

        private void ValidarExpressaoLambda<T1>(Expression<Func<T, T1>> expressao)
        {
            if (!(expressao.Body is MemberExpression))
            {
                throw new Exception(string.Format("A expressão {0} não se refere a uma propriedade (Property) do objeto {1}.", expressao.ToString(), typeof(T).ToString()));
            }
        }

        public T Unproxy(T objeto)
        {
            return Session.GetSessionImplementation().PersistenceContext.Unproxy(objeto) as T;
        }

    }
}