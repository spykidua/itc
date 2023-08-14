﻿using System;

namespace ITC.DataAccess.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
