using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }

        //como iremos ter uma UsuarioId, iremos fazer uma referência. Iremos ter uma propriedade do tipo UsuarioModel
        public virtual UsuarioModel? Usuario { get; set; }//se vamos ter uma referência/ligação com usuário com a tarefa, e demos o atributo de UsuarioId, ele vai procurar a referência da classe agregada exatamente com o mesmo nome do nosso atributo, removendo o Id do nome 'UsuarioId'. O prórpio EntityFramework já percebe isso.
    }
}
