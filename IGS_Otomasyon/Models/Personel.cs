//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IGS_Otomasyon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personel
    {
        public Personel()
        {
            this.Muayene = new HashSet<Muayene>();
        }
    
        public int PersonelId { get; set; }
        public int Gorevi { get; set; }
        public string CepTel { get; set; }
        public string PersonelNo { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public bool Arsivlendi { get; set; }
        public int OgrenimId { get; set; }
        public int IletisimId { get; set; }
        public int KimlikId { get; set; }
        public int SabikaId { get; set; }
        public int SaglikId { get; set; }
    
        public virtual Iletisim Iletisim { get; set; }
        public virtual Kimlik Kimlik { get; set; }
        public virtual ICollection<Muayene> Muayene { get; set; }
        public virtual Ogrenim Ogrenim { get; set; }
        public virtual Sabika Sabika { get; set; }
        public virtual Saglik Saglik { get; set; }
    }
}