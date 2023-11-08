using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskListServices.Application.CQRS.Command.Create;
using TaskListServices.Application.CQRS.Command.GetAll;
using TaskListServices.Application.Interface;

namespace UserServices.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTaskListServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICreateTaskList, CreateTaskList>();

            services.AddScoped<CreateTaskListCommand>();
            services.AddScoped<CreateTaskListHandler>();

            services.AddScoped<IGetTaskList,GetTaskList>();
            services.AddScoped<TaskListCommand>();
            services.AddScoped<TaskListHandler>();


            return services;
        }
    }
}
