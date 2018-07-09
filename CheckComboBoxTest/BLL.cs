using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace BackupSQLServer
{
    public class BLL
    {
        public string[] GetDbNames(Obj obj)
        {
            try
            {
                DataTable dt = new DAL().GetDbNames(obj);

                string[] result = new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result[i] = dt.Rows[i]["name"].ToString();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
