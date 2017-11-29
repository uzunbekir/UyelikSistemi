using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme1MVC.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int DersId { get; set; }
        //Mapping
        public virtual Ders Ders { get; set; }

    }
}