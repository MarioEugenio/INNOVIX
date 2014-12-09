using Innovix.Base.Data.Repository;
using Innovix.Base.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Innovix.Base.Domain.Service.Impl.Service
{
    public abstract class ServiceCRUD<TEntidade> : IServiceCRUD<TEntidade>
       where TEntidade : EntityBase
    {
        private readonly IRepository<TEntidade> Repositorio;
        protected List<string> mensagensValidacao = new List<string>();

        public ServiceCRUD(IRepository<TEntidade> repositorio)
        {
            Repositorio = repositorio;
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return Repositorio.ObterPorId(id);
        }

        public virtual IEnumerable<TEntidade> Listar()
        {
            return Repositorio.Listar();
        }

        public virtual IEnumerable<TEntidade> Listar<TProperty>(Expression<Func<TEntidade, TProperty>> incluirPropriedade)
        {
            return Repositorio.Listar(incluirPropriedade);
        }

        public IEnumerable<TEntidade> Listar<T1, T2, T3>(Expression<Func<TEntidade, T1>> prop1, Expression<Func<TEntidade, T2>> prop2, Expression<Func<TEntidade, T3>> prop3)
        {
            return Repositorio.Listar(prop1, prop2, prop3);
        }

        public IEnumerable<TEntidade> Listar<T1, T2>(Expression<Func<TEntidade, T1>> prop1, Expression<Func<TEntidade, T2>> prop2)
        {
            return Repositorio.Listar(prop1, prop2);
        }

        public virtual void Excluir(int id)
        {
            var entidade = Repositorio.ObterPorId(id);
            Repositorio.Apagar(entidade);
        }

        public virtual void ExcluirEntidade(TEntidade entidade)
        {
            Repositorio.Apagar(entidade);
        }

        public virtual void Salvar(TEntidade entidade)
        {
            Repositorio.Salvar(entidade);
        }

        public IEnumerable<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> where)
        {
            return Repositorio.Pesquisar(where);
        }

        public IEnumerable<TEntidade> Pagination(Expression<Func<TEntidade, bool>> where, int limit, int offset)
        {
            return Repositorio.Pagination(where, limit, offset);
        }
    }
}