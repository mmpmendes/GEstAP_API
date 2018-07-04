using EstruturaAP_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GEstAP_API.Models
{
    public class EntidadeNode
    {
        [DataMember]
        public int CodEstruturaInterno { get; set; }
        [DataMember]
        public string CodEstrutura { get; set; }
        [DataMember]
        public int CodEntidade { get; set; }
        [DataMember]
        public string Designacao { get; set; }
        [DataMember]
        public string Sigla { get; set; }
        [DataMember]
        public int? Supervisor { get; set; }
        [DataMember]
        public List<EntidadeNode> children { get; set; }

        public EntidadeNode()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="est"></param>
        public EntidadeNode(Estrutura est)
        {
            CodEntidade = est.CodEntidade;
            CodEstrutura = est.CodEstrutura;
            CodEstruturaInterno = est.CodEstruturaInterno;
            Designacao = est.Entidade?.Designacao;
            Sigla = est.Entidade?.Sigla;
            Supervisor = est.Supervisor?.Supervisor?.CodEstruturaInterno;
        }
    }
}