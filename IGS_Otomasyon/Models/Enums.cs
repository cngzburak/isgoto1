using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IGS_Otomasyon.Models
{
    public enum BildirimType
    {
        Evet,
        Hayır
    }
    public enum MuayeneSonucType
    {
        [Display(Name = "Gürültülü Ortamda Çalışamaz")]
        GurultuluCalisamaz,
        [Display(Name = "Kimyasal Maddelerle Çalışamaz")]
        KimyasalCalisamaz
    }
    public enum MuayeneTurType
    {
        [Display(Name = "Aralıklı Kontrol Muayeneleri")]
        AralikliMuayene,
        [Display(Name = "İş Kazası Nedenli Muayene")]
        IsKazasiNedeni
    }
    public enum MeslekType
    {
        [Display(Name = "Bilgisayar Mühendisi")]
        BilgisayarMuhendisi,
        [Display(Name = "Geliştirici")]
        Developer
    }
    public enum CinsiyetType
    {
        Seç,
        Erkek,
        Kadin
    }
    public enum MedeniHalType
    {
        Evli = 1,
        Bekar = 2
    }
    public enum KanGrubuType
    {
        Rh0P = 1,
        Rh0N = 2,
        RhAP = 3,
        RhAN = 4,
        RhBP = 5,
        RhBN = 6,
        RhABP = 7,
        RhABN = 8
    }
    public enum GorevType
    {
        Mudur = 1,
        Muhendis = 2
    }
}