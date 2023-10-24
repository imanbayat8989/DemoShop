using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Utils
{
    public static class PathExtensions
    {
        #region default images

        public static string DefaultAvatar = "/img/defaults/avatar.jpg";

        #endregion 


        #region user avatar

        public static string UserAvatarOrigin = "/Content/Images/UserAvatar/origin/";
        public static string UserAvatarOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/origin/");

        public static string UserAvatarThumb = "/Content/Images/UserAvatar/Thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Thumb/");


        #endregion

        #region slider

        public static string SliderOrigin = "/img/slider/";

        #endregion

        #region banner

        public static string BannerOrigin = "/img/bg/";

        #endregion
    }
}
