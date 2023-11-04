﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.DataLayer.DTO.Paging
{
    public class BasePaging
    {
        public BasePaging()
        {
            PageId = 1;
            TakeEntity = 10;
            HowManyShowPageAfterAndBefore = 3;
        }

        public int PageId { get; set; }

        public int PageCount { get; set; }

        public int AllEntitiesCount { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public int TakeEntity { get; set; }

        public int SkipEntity { get; set; }

        public int HowManyShowPageAfterAndBefore { get; set; }

        public string GetCurrentPagingStatus()
        {
            var startItem = 1;
            var endItem = AllEntitiesCount;

            if (EndPage > 1)
            {
                startItem = (PageId - 1) * TakeEntity + 1;
                endItem = PageId * TakeEntity;
            }

            return $"نمایش {startItem}-{endItem} از {AllEntitiesCount}";
        }

        public BasePaging GetCurrentPaging()
        {
            return this;
        }
    }
}
