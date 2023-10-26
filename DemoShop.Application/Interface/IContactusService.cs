using DemoShop.DataLayer.DTO.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.Application.Interface
{
    public interface IContactusService : IAsyncDisposable
    {
        Task CreateContactUs(CreateContactUsDTO contact, string userIp, long? userId);

        Task<AddTicketResult> AddUserTicket(AddTicketDTO ticket, long userId);

        Task<FilterTicketDTO> FilterTickets(FilterTicketDTO filter);

        Task<TicketDetailDTO> GetTicketForShow(long ticketId, long userId);

        Task<AnswerTicketResult> AnswerTicket(AnswerTicketDTO answer, long userId);

    }
}
