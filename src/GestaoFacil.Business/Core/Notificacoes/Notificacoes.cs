using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Core.Notificacoes
{
    public class Notificacoes : INotificador
    {
        private List<Notificacao> _notificacaos;

        public Notificacoes()
        {
            _notificacaos = new List<Notificacao>();
        }
        public void Handle(Notificacao notificacao)
        {
            /*Manipulando notificações*/
            _notificacaos.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacaos;
        }

        public bool TemNotificacao()
        {
            return _notificacaos.Any();
        }
    }
}
