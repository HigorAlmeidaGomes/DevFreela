using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entites
{
    public class Project : BaseEntity
    {
        public Project(int idClient, int idFreelancer, string title, string description, decimal totalCost)
        {
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            CreateAt = DateTime.Now;
            Comment = new List<ProjectComment>();
            Status = ProjectStatusEnum.Created;
        }

        public int IdClient { get; private set; }

        public int IdFreelancer { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime CreateAt { get; private set; }

        public DateTime? StartedAt { get; private set; }

        public DateTime FinishedAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectComment> Comment { get; private set; }

    }
}