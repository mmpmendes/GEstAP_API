//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstruturaAP_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estrutura
    {    
        public int CodEstruturaInterno { get; set; }
        public string CodEstrutura { get; set; }
        public Nullable<short> Nivel { get; set; }
        public Nullable<int> Depende { get; set; }
        public int CodEntidade { get; set; }
        public string CodDistrito { get; set; }
        public string CodConcelho { get; set; }
        public bool Ativo { get; set; }
        public Nullable<int> Ordem { get; set; }
    
        public virtual Entidade Entidade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estrutura> Dependentes { get; set; }
        public virtual Estrutura Supervisor { get; set; }
    }
}
