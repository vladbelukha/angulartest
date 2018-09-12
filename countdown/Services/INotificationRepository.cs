using countdown.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace countdown.Services
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNotifications();
        Notification GetNotificationById(Guid id);
        void CreateNotification(Notification notification);
        bool Save();
    }
}
