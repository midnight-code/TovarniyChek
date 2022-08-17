﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace TovarniyChek.Classes
{
    public class ReadeBase
    {
        private int _id = 0;
        public int ID
        {
            get;
            set;
        }
        private string _name = "";
        public string Name { get; set; }
        private string _adress = "";
        public string Adress { get; set; }
        private int _inn = 0;
        public int INN { get; set; }
        private int _kpp = 0;
        public int Kpp { get; set; }
        private int _tipID = 0;
        public int TipID { get; set; }

        public ReadeBase(int id, string name, string adress, int inn, int kpp, int tipid)
        {
            this.Name = name;
            this.Adress = adress;
            this.INN = inn;
            this.Kpp = kpp;
            this.TipID = tipid;
        }

        public static ReadeBase GetIspolnitel(int id)
        {
            string connString = TovarniyChek.Properties.Settings.Default.ChekBasesConnectionString;
            var dataContext = new DataContext(connString);
            ReadeBase ispolnitel = null;
            return ispolnitel;
        }
    }
}
