using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Model
{
    public class UserTask
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } // "Pending", "In Progress", "Completed"
        public int AssignedToUserId { get; set; }
        public virtual User AssignedToUser { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual ICollection<TaskNote> Notes { get; set; }
        public virtual ICollection<TaskAttachment> Attachments { get; set; }
    }
}
