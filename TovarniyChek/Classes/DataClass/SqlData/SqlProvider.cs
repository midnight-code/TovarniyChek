using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TovarniyChek.Classes.DataClass.SqlData
{
    public class SqlProvider : SCProvider
    {
       #region Примеры работы таблицы потом удалить

        /***********************************************************************
         *                                                                     *
         *                                                                     *
         *             Работаем с таблицей заказов                             *
         *                                                                     *
         *                                                                     *
         *********************************************************************
        public override List<CL_VidRabotDetails> GetVidRabotDetailsList()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sc_vidrabot_select", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetVidRabotDetailsFromListReader(ExecuteReader(cmd));
            }
        }

        public override CL_VidRabotDetails GetVidRabotDetailsByID(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sc_vidrabot_selectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetVidRabotDetailsFromReader(reader);
                else
                    return null;
            }
        }

        public override List<CL_VidRDopDetails> GetVidRabotDetailsListByIDPTM(int id_modeli)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sc_vidrabot_dopust_selectByIDModel", cn);
                cmd.Parameters.Add("@id_model", SqlDbType.Int).Value = id_modeli;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return GetVidRabotDopDetailsFromListReader(ExecuteReader(cmd));
            }
        }

        public override int GetVidRabotDetailsInsert(CL_VidRabotDetails insert)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sc_vidrabot_insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = insert.Name;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = cmd.ExecuteNonQuery();
                return (int)cmd.Parameters["@id"].Value;
            }
        }*/
       #endregion

        #region Таблица Реквизиты организации

        public override List<TC_RekvizitiDetails> GetRekvizitiDetailsAll(int id)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rekviziti WHERE [id] = @id", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                return GetRekvizitiDetailsFromListReader(ExecuteReader(cmd));
            }
        }

        #endregion
    }
}
