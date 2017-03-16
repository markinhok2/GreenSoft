//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GreenSoft_Balcao.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidoItem = new HashSet<PedidoItem>();
        }
    
        public int Pedido_ID { get; set; }
        public int Cliente_ID { get; set; }
        public int Cooperativa_ID { get; set; }
        public int Usuario_ID { get; set; }
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Cooperativa Cooperativa { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoItem> PedidoItem { get; set; }
    }
}
