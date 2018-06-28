using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GEstAP_API.Models
{
    [DataContract]
    public class EntidadeBO
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
        public int Supervisor { get; set; }
    }
}