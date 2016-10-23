using GenericDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace GenericDesign.Controllers
{
    public class OperationController : Controller
    {
        [HttpPost]
        public ActionResult GetScreenList(FormCollection Collection_)
        {
            Result<DataTable> res_ = new Result<DataTable>();
            int screenTypeID_ = Convert.ToInt32(Collection_["ScreenTypeID"]);
            string screenCode_ = Convert.ToString(Collection_["ScreenCode"]);

            string selectQuery_ = "SELECT * FROM DESING_SCREEN WITH(NOLOCK) WHERE 1=1 ";
            if (screenTypeID_ > 0)
                selectQuery_ += " AND SCRN_SCREENTYPEID =" + screenTypeID_;
            if (!string.IsNullOrEmpty(screenCode_))
                selectQuery_ += " AND SCRN_CODE ='" + screenCode_ + "'";

            using (res_.Data = DatabaseOperations.DatabaseMethods.Select(selectQuery_))
            {
                res_.IsSuccess = true;
                return Json(res_);
            }
        }
    }
}