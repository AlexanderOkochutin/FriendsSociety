//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public Nullable<int> PostTo_Id { get; set; }
        public Nullable<int> ProfileFrom_Id { get; set; }
        public Nullable<int> ProfileTo_Id { get; set; }
        public Nullable<int> Profile_Id { get; set; }
    
        public virtual Posts Posts { get; set; }
        public virtual Profiles Profiles { get; set; }
        public virtual Profiles Profiles1 { get; set; }
        public virtual Profiles Profiles2 { get; set; }
    }
}