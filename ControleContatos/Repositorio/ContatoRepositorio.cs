using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
            public ContatoRepositorio(BancoContext bancoContext)
            {
                _bancoContext = bancoContext;
            }
            public ContatoModel Adicionar(ContatoModel contato)
            {
                _bancoContext.Contatos.Add(contato);
                _bancoContext.SaveChanges();
                return contato;
            }
    }
}
