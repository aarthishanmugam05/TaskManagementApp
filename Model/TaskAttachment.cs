namespace TaskManagementSystem.Model
{
    public class TaskAttachment
    {
        public int TaskAttachmentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public int TaskId { get; set; }
        public virtual UserTask Task { get; set; }
        public int UploadedByUserId { get; set; }
        public virtual User UploadedByUser { get; set; }
    }
}
