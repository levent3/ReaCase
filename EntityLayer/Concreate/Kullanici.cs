﻿using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Kullanici:BaseEntity
    {


        public string KullaniciAdi { get; set; }       
        public string Sifre { get; set; }
    }
}
