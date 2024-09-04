using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Model;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;

    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserTask>> GetTasksByUserIdAsync(int userId)
    {
        return await _context.Tasks
            .Where(t => t.AssignedToUserId == userId)
            .Include(t => t.Notes)
            .Include(t => t.Attachments)
            .ToListAsync();
    }

    public async Task<UserTask> CreateTaskAsync(UserTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<UserTask> UpdateTaskAsync(UserTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTaskAsync(int taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task == null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<UserTask>> GetTasksByManagerIdAsync(int managerId)
    {
        var users = await _context.Users
            .Where(u => u.Role == "Employee" && u.Tasks.Any(t => t.CreatedByUserId == managerId))
            .Select(u => u.UserId)
            .ToListAsync();

        return await _context.Tasks
            .Where(t => users.Contains(t.AssignedToUserId))
            .Include(t => t.Notes)
            .Include(t => t.Attachments)
            .ToListAsync();
    }
}
