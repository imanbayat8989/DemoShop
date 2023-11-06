using DemoShop.DataLayer.DTO.SellerWallet;
using DemoShop.DataLayer.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface ISellerWalletService
    {
        #region wallet

        Task<FilterSellerWalletDTO> FilterSellerWallet(FilterSellerWalletDTO filter);
        Task AddWallet(SellerWallet wallet);

        #endregion
    }
}
