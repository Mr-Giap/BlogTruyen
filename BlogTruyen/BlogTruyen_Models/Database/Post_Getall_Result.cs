//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogTruyen_Models.Database
{
    using System;
    
    public partial class Post_Getall_Result
    {
        public System.Guid IdPost { get; set; }
        public string PostName { get; set; }
        public string NameAscii { get; set; }
        public string Introduction { get; set; }
        public string Avatar { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public string Note { get; set; }
        public System.Guid IdUser { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public bool IsDelete { get; set; }
        public bool IsFull { get; set; }
        public int IdCategory { get; set; }
        public string Type { get; set; }
        public string Child { get; set; }
    }
}