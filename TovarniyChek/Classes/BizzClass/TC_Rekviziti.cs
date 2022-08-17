using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TovarniyChek.Classes.DataClass;

namespace TovarniyChek.Classes.BizzClass
{
    public class TC_Rekviziti
    {
        private int _id = 0;
        public int ID { get; set; }
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

        public TC_Rekviziti(int id, string name, string adress, int inn, int kpp, int tipid)
        {
            this.Name = name;
            this.Adress = adress;
            this.INN = inn;
            this.Kpp = kpp;
            this.TipID = tipid;
        }

        public static List<TC_Rekviziti> GetFullRekviziti()
        {
            List<TC_Rekviziti> proiz = null;
            List<TC_RekvizitiDetails> proizdetails = SCProvider.Instance.GetRekvizitiDetailsAll(1);
            proiz = GetRekvizitiAll(proizdetails);
            return proiz;
        }

        private static TC_Rekviziti GetRekvizit(TC_RekvizitiDetails record)
        {
            return new TC_Rekviziti(record.ID, record.Name, record.Adress, record.ID, record.Kpp, record.TipID);
        }
        
        private static List<TC_Rekviziti> GetRekvizitiAll(List<TC_RekvizitiDetails> recordc)
        {
            List<TC_Rekviziti> rekvizit = new List<TC_Rekviziti>();
            foreach (TC_RekvizitiDetails record in recordc)
                rekvizit.Add(GetRekvizit(record));
            return rekvizit;
        }
    }
}
