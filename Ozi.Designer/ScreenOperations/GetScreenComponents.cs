using Ozi.Designer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenOperations
{
    public class GetScreenComponents
    {
        public static ScreenModel GetScreenProperties(string ScreenCode_)
        {
            ScreenModel screenModel_ = new ScreenModel();
            string HTMLCode_ = "";
            string elementCode_ = "";
            string elementLabel_ = "";
            string elementID_ = "";

            string query = "SELECT * FROM dbo.DESING_SCREEN WITH(NOLOCK) INNER JOIN dbo.DESING_SCREENELEMENT WITH(NOLOCK) ON SCEL_SCREENID = SCRN_ID INNER JOIN dbo.DESING_ELEMENT WITH(NOLOCK) ON SCEL_ELEMENTID = ELEM_ID WHERE SCRN_CODE = '" + ScreenCode_ + "'";

            using (DataTable dt_ = DatabaseOperations.DatabaseMethods.Select(query))
            {
                if (dt_ != null && dt_.Rows.Count > 0)
                {
                    screenModel_.ScreenName = dt_.Rows[0]["SCRN_TITLE"].ToString();
                    screenModel_.ScreenComponents = new List<string>();

                    foreach (DataRow dRow_ in dt_.Rows)
                    {
                        elementID_ = dRow_["SCEL_ELEMENTHTMLID"].ToString();
                        elementLabel_ = dRow_["SCEL_ELEMENTLABEL"].ToString();
                        elementCode_ = dRow_["ELEM_HTMLDATA"].ToString();

                        HTMLCode_ = elementCode_.Replace("{{ElementLabel}}", elementLabel_).Replace("{{ElementID}}", elementID_);

                        screenModel_.ScreenComponents.Add(HTMLCode_);
                    }
                }
            }

            return screenModel_;
        }
    }
}
