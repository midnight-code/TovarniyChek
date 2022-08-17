using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TovarniyChek.Classes.DataClass
{
    public abstract class SCProvider : DataSql
    {
         static private SCProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>
        static public SCProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (SCProvider)Activator.CreateInstance(
                       Type.GetType("TovarniyChek.Classes.DataClass.SqlData.SqlProvider"));
                return _instance;
            }
        }

        public SCProvider()
        {
            this.ConnectionString = TovarniyChek.Properties.Settings.Default.Setting;
        }

        //public abstract методы для работы объектов переопределяються в SqlClass.SqlMagazinProvider.cs

       /* public abstract List<CL_ZakazDetails> GetZakaziDetailsList();
        public abstract CL_ZakazDetails GetZakaziDetailsByID(int id);
        public abstract int GetZakaziDetailsInsert(CL_ZakazDetails insert);
        public abstract bool GetZakaziDetailsUpdate(CL_ZakazDetails update);
        public abstract bool GetZakaziDetailsDelete(int id);*/
        public abstract List<TC_RekvizitiDetails> GetRekvizitiDetailsAll(int id);

        /// <summary>
        /// Абстрактные классы для Otdel
        /// </summary>
        /// <returns></returns>r

        /*protected virtual CL_ProizvodDetails GetProizvodDetailsFromReader(IDataReader reader)
        {
            return new CL_ProizvodDetails((int)reader["id"], reader["name"].ToString());
        }
        protected virtual List<CL_ProizvodDetails> GetProizvodDetailsFromListReader(IDataReader reader)
        {
            List<CL_ProizvodDetails> proizvod = new List<CL_ProizvodDetails>();
            while (reader.Read())
                proizvod.Add(GetProizvodDetailsFromReader(reader));
            return proizvod;
        }*/
        protected virtual TC_RekvizitiDetails GetRekvizitiDetailsFromReader(IDataReader reader)
        {
            return new TC_RekvizitiDetails((int)reader["id"], reader["name"].ToString(), reader["Adress"].ToString(), Convert.ToInt32(reader["inn"]), Convert.ToInt32(reader["kpp"]), Convert.ToInt32(reader["id_tip"]));
        }
        protected virtual List<TC_RekvizitiDetails> GetRekvizitiDetailsFromListReader(IDataReader reader)
        {
            List<TC_RekvizitiDetails> rekvizit = new List<TC_RekvizitiDetails>();
            while (reader.Read())
                rekvizit.Add(GetRekvizitiDetailsFromReader(reader));
            return rekvizit;
        }
    }
}
