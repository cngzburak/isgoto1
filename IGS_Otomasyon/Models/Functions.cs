using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace IGS_Otomasyon.Models
{
    public static class Functions
    {
        public static List<Personel> GetPersonelList()
        {
            using (var db = new IsgEntities())
            {
                return db.Personel.Include(i=>i.Kimlik).Where(w => !w.Arsivlendi).ToList();
            }
        }
    }
}