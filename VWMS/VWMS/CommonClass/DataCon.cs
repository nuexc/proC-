using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;        //连接Access数据库
using System.Windows.Forms;

namespace VWMS.CommonClass
{
    class DataCon
    {
        public OleDbConnection getCon()
        {
            string strDPath = Application.StartupPath;  //获取程序运行路径
            string strDataSource = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + strDPath.Substring(0, strDPath.LastIndexOf("\\")).Substring(0, strDPath.Substring(0, strDPath.LastIndexOf("\\")).LastIndexOf("\\")) + "\\DataBase\\db_VWMS.mdb";
            OleDbConnection oledbCon = new OleDbConnection(strDataSource);

            return oledbCon;
        }
    }
}
