using APIServices.CMS;
using APIServices.CMS.QuanLyDanhMuc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    [AuthorizationAttribute]
    public class CommonController : Controller
    {
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public CommonController(IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyDanhMucService = QuanLyDanhMucService;
        }

        [HttpPost]
        public async Task<JsonResult> TreeChuyenMuc()
        {
            try
            {
                tbl_CategoryModel requestModel = new tbl_CategoryModel();
                List<tbl_CategoryModel> ReponeAllChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
                List<TreeNodeModel> Result = NodeChuyenMuc(ReponeAllChuyenMuc, 0);
                return Json(Result);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public List<TreeNodeModel> NodeChuyenMuc(List<tbl_CategoryModel> DanhSachChuyenMuc, int IdCha)
        {
            List<TreeNodeModel> Result = new List<TreeNodeModel>();
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == IdCha))
                {
                    TreeNodeModel Node = new TreeNodeModel();
                    Node.id = item.ID.ToString();
                    Node.text = item.Name;
                    Node.type = "folder";
                    Node.id = JsonConvert.SerializeObject(Node);
                    var CheckChuyenMucCon = DanhSachChuyenMuc.Where(e => e.ParentID == item.ID).ToList();
                    if (CheckChuyenMucCon.Count > 0)
                    {
                        Node.children = NodeChuyenMuc(DanhSachChuyenMuc, item.ID);
                    }
                    Result.Add(Node);
                }
            }
            return Result;
        }
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var fileNameNew = Guid.NewGuid() + fileName;
                    const string folderPath = "/FileUploaded/Upload/Images/";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string fullPath = Path.Combine(Server.MapPath("~/FileUploaded/Upload/Images"), fileNameNew);
                    file.SaveAs(fullPath);


                    //System.IO.File.Delete(fullPath);

                    return Json(new
                    {
                        data = fileNameNew,
                        type = CommonConstants.SUCCESS
                    });
                }
                return Json(new { type = CommonConstants.ERROR });
            }
            catch (Exception ex)
            {
                return Json(new { type = CommonConstants.ERROR, message = ex.Message });
            }
        }
    }
}