using TaskManagementSystem.Model;

namespace TaskManagementSystem.Data
{
    public interface ITaskService
    {
        Task<IEnumerable<UserTask>> GetTasksByUserIdAsync(int userId);
        Task<UserTask> CreateTaskAsync(UserTask task);
        Task<UserTask> UpdateTaskAsync(UserTask task);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<UserTask>> GetTasksByManagerIdAsync(int managerId);
    }
}
