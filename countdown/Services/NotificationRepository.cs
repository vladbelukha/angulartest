using System;
using System.Collections.Generic;
using System.Linq;
using countdown.Repository;

namespace countdown.Services
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationContext _context;

        public NotificationRepository(NotificationContext context)
        {
            _context = context;
        }

        public void CreateNotification(Notification notification)
        {
            notification.Id = Guid.NewGuid();
            _context.Notifications.Add(notification);
        }

        public Notification GetNotificationById(Guid id)
        {
            return _context.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _context.Notifications.ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
