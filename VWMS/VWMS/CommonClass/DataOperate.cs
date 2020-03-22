using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace VWMS.CommonClass
{
    class DataOperate
    {
        DataCon dataCon = new DataCon();
        OleDbConnection oledbcon;
        OleDbCommand oledbcom;
        OleDbDataAdapter oledbda;
        DataSet ds;

        public void getCom(string strCon)
        {
            oledbcon = dataCon.getCon();
            oledbcom = new OleDbCommand(strCon, oledbcon);
            oledbcon.Open();
            oledbcom.ExecuteNonQuery();
            oledbcon.Close();
        }

        public DataSet getDs(string strCon,string tbname)
        {
            oledbcon = dataCon.getCon();
            oledbda = new OleDbDataAdapter(strCon, oledbcon);
            ds = new DataSet();
            oledbda.Fill(ds, tbname);
            return ds;
        }
    }
}
