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
    
    public partial class Chapter_Getall_Result
    {
        public System.Guid IdChapter { get; set; }
        public System.Guid IdPost { get; set; }
        public int NameChap { get; set; }
        public string Title { get; set; }
        public string ChapContent { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public bool IsDelete { get; set; }
    }
}
