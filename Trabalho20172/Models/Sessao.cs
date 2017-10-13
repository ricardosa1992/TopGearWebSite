using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho20172.Models
{
        public static class Sessao
        {
            /*
            OBS: Evitar criar mais Sessions. Na dúvida sobre minha orientação, faça uma pesquisa sobre 'escalabilidade' e o 'prejuízo no uso de Sessions'
            */

            //Session que carrega o ID do usuário logado
            public static int? IdUsuarioLogado
            {
                get { return Convert.ToInt32(HttpContext.Current.Session["IdUsuarioLogado"]); }
                set { HttpContext.Current.Session.Add("idUsuarioLogado", value); }
            }
        
            public static string LoginUsuario
            {
                get { return (string)HttpContext.Current.Session["login_usuario"]; }
                set { HttpContext.Current.Session.Add("login_usuario", value); }
            }
        }
    
}