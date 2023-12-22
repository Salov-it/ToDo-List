using TaskList_Frontend.Services.TaskListApi.Models.TaskList;

namespace TaskList_Frontend.Services.TaskListApi.Interface
{
    public interface ITaskListControllers
    {
        Task<List<TaskViewModel>> GetAllTaskList();
        Task<TaskListStatusModel> TaskListAdd(TaskListAddModel taskListAdd);
        Task<string> ChangeTask(ChangeTaskListModel changeTaskList);
        Task<string> Delete(TaskListDeleteModel taskListDeleteModel);
    }
} 
