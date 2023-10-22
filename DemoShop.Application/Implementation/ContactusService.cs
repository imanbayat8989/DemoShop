using DemoShop.Application.Interface;
using DemoShop.DataLayer.DTO.Contacts;
using DemoShop.DataLayer.Entities.Contacts;
using DemoShop.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Implementation
{
    public class ContactusService : IContactusService
    {
        #region Constructor

        private readonly IGenericRepository<ContactUs> _contactUsRepository;

        public ContactusService(IGenericRepository<ContactUs> contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        #endregion

        #region ContactUS
        public async Task CreateContactUs(CreateContactUsDTO contact, string userIp, long? userId)
        {
            var newContact = new ContactUs
            {
                UserId = userId != null && userId.Value != 0 ? userId.Value : (long?)null,
                Subject = contact.Subject,
                Email = contact.Email,
                UserIp = userIp,
                Text = contact.Text,
                FullName = contact.FullName
            };

            await _contactUsRepository.AddEntity(newContact);
            await _contactUsRepository.SaveChanges();
        }

        public async ValueTask DisposeAsync()
        {
            await _contactUsRepository.DisposeAsync();
        }
        #endregion
    }
}
