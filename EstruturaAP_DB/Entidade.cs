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
    
    public partial class Entidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entidade()
        {
            this.Estrutura = new HashSet<Estrutura>();
        }
    
        public int CodEntidade { get; set; }
        public string Designacao { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
        public bool Sugere { get; set; }
        public bool Bepa { get; set; }
        public Nullable<bool> ExportarArea { get; set; }
        public Nullable<bool> ExportarIlha { get; set; }
        public Nullable<bool> ExportarConcelho { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estrutura> Estrutura { get; set; }
    }
}
