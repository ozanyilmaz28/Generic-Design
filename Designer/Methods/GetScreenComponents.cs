using Designer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer
{
    public class GetScreenComponents
    {
        private static SqlConnection connection_ = new SqlConnection("Data Source=LA-178\\SQLEXPRESS; Initial Catalog=NEWDESIGN; User Id=testeruser; password=qwer1234;");

        public static ScreenModel GetScreenProperties(string ScreenCode_)
        {
            ScreenModel screenModel_ = new ScreenModel();
            string HTMLCode_ = "";
            string elementCode_ = "";
            string elementLabel_ = "";
            string elementID_ = "";

            connection_.Open();
            DataTable viewDataTable_ = new DataTable();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM dbo.DESING_SCREEN WITH(NOLOCK) INNER JOIN dbo.DESING_SCREENELEMENT WITH(NOLOCK) ON SCEL_SCREENID = SCRN_ID INNER JOIN dbo.DESING_ELEMENT WITH(NOLOCK) ON SCEL_ELEMENTID = ELEM_ID WHERE SCRN_CODE = '" + ScreenCode_ + "'", connection_);
            adptr.Fill(viewDataTable_);
            connection_.Close();

            screenModel_.ScreenName = viewDataTable_.Rows[0]["SCRN_TITLE"].ToString();
            screenModel_.ScreenComponents = new List<string>();

            foreach (DataRow dRow_ in viewDataTable_.Rows)
            {
                elementID_ = dRow_["SCEL_ELEMENTHTMLID"].ToString();
                elementLabel_ = dRow_["SCEL_ELEMENTLABEL"].ToString();
                elementCode_ = dRow_["ELEM_HTMLDATA"].ToString();

                HTMLCode_ = elementCode_.Replace("{{ElementLabel}}", elementLabel_).Replace("{{ElementID}}", elementID_);

                screenModel_.ScreenComponents.Add(HTMLCode_);
            }

            return screenModel_;
        }
    }
}
