using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Innovix.Base.Domain.Entity; 

namespace Innovix.Base.Persistencia.NHibernate.Map {
    
    
    public class TbUsuarioMap : ClassMap<TbUsuario> {
        
        public TbUsuarioMap() {
			Table("tb_usuario");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("id_usuario");
			References(x => x.tbPerfil).Column("id_perfil");
			References(x => x.tbTipoUsuario).Column("id_tipo_usuario");
			Map(x => x.noUsuario).Column("no_usuario").Not.Nullable().Length(50);
			Map(x => x.codSenha).Column("cod_senha").Not.Nullable().Length(35);
			Map(x => x.codCpfCnpj).Column("cod_cpf_cnpj").Not.Nullable().Length(18);
			Map(x => x.noEmail).Column("no_email").Length(30);
			Map(x => x.noTelefone).Column("no_telefone").Length(20);
			//HasMany(x => x.relEmpresaUsuario).KeyColumn("id_usuario");
			HasMany(x => x.tbLogUsuario).KeyColumn("id_usuario");
			//HasMany(x => x.tbLogitem).KeyColumn("id_usuario");
			//HasMany(x => x.tbLoglote).KeyColumn("id_usuario");
			//HasMany(x => x.tbLogsaco).KeyColumn("id_usuario");
			//HasMany(x => x.tbSincUsuario).KeyColumn("id_usuario");
        }
    }
}
