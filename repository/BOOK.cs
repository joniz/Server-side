//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.AUTHORs = new HashSet<AUTHOR>();
        }
    
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Nullable<int> SignId { get; set; }
        public string PublicationYear { get; set; }
        public string publicationinfo { get; set; }
        public Nullable<short> pages { get; set; }
    
        public CLASSIFICATION CLASSIFICATION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<AUTHOR> AUTHORs { get; set; }
    }
}
