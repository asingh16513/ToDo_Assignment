﻿using System;

namespace Domain.Models
{
    public class UserAuthResult
    {
        public string AuthToken { get; set; }
        public Guid RequestId { get; set; }
        public int UserId { get; set; }
    }
}
