using DemoShop.DataLayer.Entities.common;
using DemoShop.DataLayer.Entities.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoShop.DataLayer.Entities.Wallet
{
    public class SellerWallet : BaseEntities
    {
        #region properties

        public long SellerId { get; set; }

        public int Price { get; set; }

        public TransactionType TransactionType { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Description { get; set; }

        #endregion

        #region relations

        public Seller Seller { get; set; }

        #endregion
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}
