using System;

var taskManager = new TaskManager();

Console.WriteLine("Task Tracker Demo");
Console.WriteLine("=================");
Console.WriteLine($"Pending tasks: {taskManager.GetPendingTaskCount()}");
Console.WriteLine($"Completed tasks: {taskManager.GetCompletedTaskCount()}");
Console.WriteLine($"Next task: {taskManager.GetNextTask()}");

public class TaskManager
{
    private readonly List<string> _tasks = new()
    {
        "Review pull request",
        "Write unit tests",
        "Deploy to staging"
    };

    private readonly HashSet<string> _completedTasks = new(StringComparer.OrdinalIgnoreCase)
    {
        "Write unit tests"
    };

    public int GetPendingTaskCount() => _tasks.Count(t => !_completedTasks.Contains(t));

    public int GetCompletedTaskCount() => _completedTasks.Count;

    public string GetNextTask()
    {
        var pending = _tasks.FirstOrDefault(t => !_completedTasks.Contains(t));
        return pending ?? "No pending tasks";
    }
}
