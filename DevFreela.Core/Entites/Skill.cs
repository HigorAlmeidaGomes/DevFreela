﻿using System;

namespace DevFreela.Core.Entites
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreateAt = DateTime.Now;
        }

        public string Description { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}
