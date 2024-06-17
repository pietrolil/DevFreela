using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createAt)
        {
            Id = id;
            Title = title;
            CreatedAt = createAt;
        }

        public int Id { get; set; }

        public string Title {  get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
