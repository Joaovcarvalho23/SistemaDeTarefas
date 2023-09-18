using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaDeTarefasDBContext : DbContext
    {
        public SistemaDeTarefasDBContext(DbContextOptions<SistemaDeTarefasDBContext> options)
            : base(options)
        {}

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
//por estarmos usando um entity framework, aqui estamos trabalhando com um ORM, ele vai facilitar a gente a trabalhar com banco de dados e independente do banco de dados também.
//O ORM ele vai fazer toda a estrutura de entidade pra dentro do código, e depois vamos criar o nosso banco de dados e as tabelas através do nosso código Csharp.
//Nesse DbContext, estaremos configurando nossas tabelas e as configurações do banco de dados. por exemplo, o nosso UsuarioModel representa uma tabela no banco de dados, a tabela usuários. 
