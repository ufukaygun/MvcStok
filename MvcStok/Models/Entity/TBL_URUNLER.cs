//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_URUNLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_URUNLER()
        {
            this.TBL_SATISLAR = new HashSet<TBL_SATISLAR>();
        }
    
        public int URUNID { get; set; }
        public string URUNAD { get; set; }
        public Nullable<short> URUNKATEGORI { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public string MARKA { get; set; }
        public Nullable<byte> STOK { get; set; }
    
        public virtual TBL_KATEGORI TBL_KATEGORI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_SATISLAR> TBL_SATISLAR { get; set; }
    }
}
