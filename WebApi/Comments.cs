//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int PersonId { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
    
        public virtual Persons Person { get; set; }
    }
}
