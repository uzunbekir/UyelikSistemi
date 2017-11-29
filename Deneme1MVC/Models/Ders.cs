using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme1MVC.Models
{
    public class Ders
    {
        public int DersId { get; set; }
        public string DersAdi { get; set; }

        public virtual List<Ogrenci> Ogrenci { get; set; }
    }
}