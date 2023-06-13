using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            //base.ObterId();
        }

        public int IdClient { get; private set; }
        public User Client { get; private set; }

        public int IdFreelancer { get; private set; }

        public User Freelancer { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime CreateAt { get; private set; }

        public DateTime? StartedAt { get; private set; }

        public DateTime? FinishedAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectComment> Comment { get; private set; }

        public void Cancel()
        {
            if (Status != ProjectStatusEnum.Cancelled) Status = ProjectStatusEnum.Cancelled;
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                StartedAt = DateTime.Now;
                Status = ProjectStatusEnum.InProgress;
            }
        }

        public void Finish()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public void Pendig()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.PaymentPending;
                FinishedAt = null;
            }
        }
    }
}