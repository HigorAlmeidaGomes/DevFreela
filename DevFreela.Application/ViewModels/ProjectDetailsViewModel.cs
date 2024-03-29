﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string titlee, string description,decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Titlee = titlee;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            ClientFullName= clientFullName;
            FreelancerFullName= freelancerFullName;
        }

        public int Id { get; private set; }
        public string Titlee { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }

        public DateTime? StartedAt { get; private set; }

        public DateTime? FinishedAt { get; private set; }

        public string  ClientFullName { get; set; }

        public string FreelancerFullName { get; set; }
    }
}
