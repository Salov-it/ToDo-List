using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Services.TaskListApi.Interface
{
    public interface ITaskListControllers
    {
        Task<TaskViewModel> GetAllTaskList();
    }
}
