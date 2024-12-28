// using System;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using TasksManager.Models;
// using TasksManager.Services;
// using Plugin.LocalNotification;
//
// public class TaskNotificationService
// {
//     private readonly TaskService _taskService;
//
//     public TaskNotificationService()
//     {
//         _taskService = new TaskService();
//     }
//
//     public async System.Threading.Tasks.Task CheckAndNotifyAsync()
//     {
//         var tasks = await _taskService.GetTasksAsync();
//         foreach (var task in tasks.Where(t => !t.IsCompleted))
//         {
//             var timeUntilDue = task.DueDate - DateTime.Now;
//
//             if (timeUntilDue.TotalDays <= 1 && timeUntilDue.TotalDays > 0.98)
//             {
//                 SendNotification(task, "Task due tomorrow!");
//             }
//             else if (timeUntilDue.TotalHours <= 3 && timeUntilDue.TotalHours > 2.9)
//             {
//                 SendNotification(task, "Task due in 3 hours!");
//             }
//             else if (timeUntilDue.TotalHours <= 1 && timeUntilDue.TotalHours > 0.9)
//             {
//                 SendNotification(task, "Task due in 1 hour!");
//             }
//         }
//     }
//
//     private void SendNotification(TasksManager.Models.Task task, string message)
//     {
//         var notification = new NotificationRequest
//         {
//             Title = "Task Reminder",
//             Description = $"{message}: {task.Title}",
//             Schedule = new NotificationRequestSchedule
//             {
//                 NotifyTime = DateTime.Now.AddSeconds(1)
//             }
//         };
//
//         LocalNotificationCenter.Current.Show(notification);
//         // NotificationCenter.Show(notification);
//     }
// }