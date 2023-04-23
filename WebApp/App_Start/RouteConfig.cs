using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "TrangChu",
              url: "Trang-chu.htm",
              defaults: new { controller = "Home", action = "Index", ID = UrlParameter.Optional },
              new[] { "WebApp.Controllers" }
          );

            routes.MapRoute(
              name: "AlbumAnh",
              url: "Album_Anh.htm",
              defaults: new { controller = "AlbumAnh", action = "Index", ID = UrlParameter.Optional },
              new[] { "WebApp.Controllers" }
          );

            routes.MapRoute(
              name: "Video",
              url: "Video.htm",
              defaults: new { controller = "Video", action = "Index", ID = UrlParameter.Optional },
              new[] { "WebApp.Controllers" }
          );

            routes.MapRoute(
             name: "VideoCT",
             url: "{alias}_vd-{Id}.htm",
             defaults: new { controller = "Video", action = "XemChiTietVideo", Id = UrlParameter.Optional },
             new[] { "WebApp.Controllers" }
         );



            routes.MapRoute(
              name: "Audio",
              url: "Audio.htm",
              defaults: new { controller = "Audio", action = "Index", ID = UrlParameter.Optional },
              new[] { "WebApp.Controllers" }
          );

            routes.MapRoute(
             name: "AudioCT",
             url: "{alias}_au-{Id}.htm",
             defaults: new { controller = "Audio", action = "XemChiTietAudio", Id = UrlParameter.Optional },
             new[] { "WebApp.Controllers" }
         );



            routes.MapRoute(
               name: "ChuyenMucBaiViet",
               url: "{alias}_cm-{ID}.htm",
               defaults: new { controller = "ChuyenMuc", action = "Index", ID = UrlParameter.Optional },
               new[] { "WebApp.C  ontrollers" }
           );
            routes.MapRoute(
              name: "ChiTietBaiViet",
              url: "{alias}_bv-{ID}.htm",
              defaults: new { controller = "TinTucView", action = "ChiTietTinTuc", ID = UrlParameter.Optional },
              new[] { "WebApp.Controllers" }
          );

            routes.MapRoute(
               name: "VanBan",
               url: "Van-ban.htm",
               defaults: new { controller = "VanBan", action = "Index", ID = UrlParameter.Optional },
               new[] { "WebApp.Controllers" }
           );

            routes.MapRoute(
                name: "ChiTiet_VanBan",
                url: "{alias}_vbdh-{ID}.htm",
                defaults: new { controller = "VanBan", action = "Index", ID = UrlParameter.Optional },
                new[] { "WebApp.Controllers" }
            );

            routes.MapRoute(
               name: "ChiTietVanBan",
               url: "{aliasCN}/{alias}_vb-{ID}.htm",
               defaults: new { controller = "VanBan", action = "ChiTietVanBan", ID = UrlParameter.Optional },
               new[] { "WebApp.Controllers" }
           );

            routes.MapRoute(
                 name: "ChiTietVanBan_alias",
                 url: "{aliasCN}/{alias}_vb-{ID}.htm",
                 defaults: new { controller = "VanBan", action = "ChiTietVanBan", ID = UrlParameter.Optional },
                 new[] { "WebApp.Controllers" }
             );

      

            routes.MapRoute(
               name: "ThongTinChiHoi",
               url: "{alias}-chtt.htm",
               defaults: new { controller = "ThongTinChiHoi", action = "Index", ID = UrlParameter.Optional },
               new[] { "WebApp.Controllers" }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "WebApp.Controllers" }
            );
        }
    }
}