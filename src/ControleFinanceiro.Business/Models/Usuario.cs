using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        virtual public IEnumerable<Lancamento> Lancamentos { get; set; }
    }
}
