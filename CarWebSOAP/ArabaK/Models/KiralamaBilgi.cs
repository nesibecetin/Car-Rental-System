//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArabaK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KiralamaBilgi
    {
        public int KiralamaID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string VerilisTarihi { get; set; }
        public string AlinisTarihi { get; set; }
        public Nullable<int> VerilisKilometre { get; set; }
        public Nullable<int> GidilenKilometre { get; set; }
        public Nullable<int> AlinanUcret { get; set; }
        public Nullable<int> Kullanici { get; set; }
        public Nullable<int> Arac { get; set; }
    
        public virtual Araba Araba { get; set; }
        public virtual Kullanici Kullanici1 { get; set; }
    }
}
