using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // "Employee", "Manager", "Admin"
        public virtual ICollection<UserTask> Tasks { get; set; }
        public virtual ICollection<TaskNote> TaskNotes { get; set; }
        public virtual ICollection<TaskAttachment> TaskAttachments { get; set; }
    }
}
