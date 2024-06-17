namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientFullname, string freelancerFullname)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishAt = finishedAt;
            ClientFullname = clientFullname;
            FreelancerFullname = freelancerFullname;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime? StartedAt { get; private set; }

        public DateTime? FinishAt { get; private set; }

        public string ClientFullname { get; private set; }

        public string FreelancerFullname { get; private set; }
    }
}
