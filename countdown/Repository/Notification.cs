using System;
using System.ComponentModel.DataAnnotations;

namespace countdown.Repository
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }
    }
}
