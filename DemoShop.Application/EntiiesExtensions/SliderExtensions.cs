﻿using DemoShop.Application.Utils;
using DemoShop.DataLayer.Entities.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.EntiiesExtensions
{
    public static class SliderExtensions
    {
        public static string GetSliderImageAddress(this Slider slider)
        {
            return PathExtensions.SliderOrigin + slider.ImageName;
        }
    }
}
