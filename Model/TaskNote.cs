using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Model
{
    public class TaskNote
    {
        public int TaskNoteId { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TaskId { get; set; }
        public virtual UserTask Task { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
