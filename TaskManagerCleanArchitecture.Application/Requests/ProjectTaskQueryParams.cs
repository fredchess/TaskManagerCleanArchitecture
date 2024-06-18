using TaskManagerCleanArchitecture.Domain.Enums;

namespace TaskManagerCleanArchitecture.Application.Requests
{
    public class ProjectTaskParameters : QueryParameters
    {
        public ProjectTaskStatusEnum[] Statuses { get; set; } = [];
        public int[] Priorities { get; set; } = [];
        public DateTime? DueDate { get; set; }
    }
}