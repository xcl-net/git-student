using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModel
{
    public class Stmodel
    {
        public int Sid{get;set;}
        public string Sname { get; set; }//不可空
        public DateTime Sbirthday{get;set;}//不可空
        public bool Sgender { get; set; }//不可空
        public decimal? Sheight { get; set; }
        public int? Sweight { get; set; }
        public string Saddress { get; set; }
    }
}
