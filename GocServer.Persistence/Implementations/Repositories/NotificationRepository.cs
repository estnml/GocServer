using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.NotificationDto;
using Microsoft.EntityFrameworkCore;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAsync(Guid id, UpsertNotificationDto notificationDto)
        {
            if (id != notificationDto.Id)
            {
                return false;
            }
            
            var objFromDb = await _context.Notifications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = notificationDto;
            _context.Entry(objFromDb).State = EntityState.Modified;

            return true;
        }
    }
}