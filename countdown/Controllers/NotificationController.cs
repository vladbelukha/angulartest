using AutoMapper;
using countdown.Model;
using countdown.Repository;
using countdown.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace countdown.Controllers
{
    [Route("api/notifications")]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository) {
            _notificationRepository = notificationRepository;
        }

        [HttpGet] IActionResult GetNotifications()
        {
            var notifications = _notificationRepository.GetNotifications();

            var notificationDto = Mapper.Map<NotificationDto>(notifications);

            return Ok(notificationDto);
        }

        [HttpGet("{id}", Name = "GetNotificationById")]
        public IActionResult GetNotificationById(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var notificationEntity = _notificationRepository.GetNotificationById(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult AddNotification([FromBody] NotificationDto notification)
        {
            if (notification == null)
            {
                return BadRequest();
            }

            var notificationEntity = Mapper.Map<Notification>(notification);

            _notificationRepository.CreateNotification(notificationEntity);
            if (_notificationRepository.Save())
            {
                throw new Exception("Save failed.");
            }

            var result = Mapper.Map<NotificationDto>(notificationEntity);

            return CreatedAtRoute("GetNotificationById", new { id = notificationEntity.Id }, result);
        }
    }
}
