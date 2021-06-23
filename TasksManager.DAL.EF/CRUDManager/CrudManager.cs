using System;
using System.Collections.Generic;
using TasksManager.DAL.EF.Models.EF;
using TasksManager.DAL.EF.DataContext;
using TasksManager.DAL.EF.Embeded.EF.Models;
using System.Linq;

namespace TasksManager.DAL.EF.CRUDManager
{
    public class CrudManager
    {
        public static List<MSubTask> LoadSubTasks(Tasks task, List<MSubTask> result)
        {
            try
            {
                using TaskManagerContext context = new();
                if(task.TasksSubTaskSubTasks != null && task.TasksSubTaskSubTasks.Count > 0)
                {
                    foreach(TasksSubTask item in task.TasksSubTaskSubTasks)
                    {
                        Tasks subTask = context.Tasks.Find(item.TaskSubTaskId);

                        if(subTask != null && !subTask.TaskId.Equals(0))
                        {
                            MSubTask mSubTask = new(subTask);

                            result.Add(mSubTask);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("LoadSubTaks: {0}", ex.Message));
            }

            return result;
        }

        public static List<MTask> LoadTasks(Tasks task, List<MTask> result)
        {
            try
            {
                using TaskManagerContext context = new();
                if (task.TasksSubTaskTasks != null && task.TasksSubTaskTasks.Count > 0)
                {
                    foreach (TasksSubTask item in task.TasksSubTaskTasks)
                    {
                        Tasks taskToAdd = context.Tasks.Find(item.TaskId);

                        if(taskToAdd != null && !taskToAdd.TaskId.Equals(0))
                        {
                            MTask mTask = new(taskToAdd);

                            result.Add(mTask);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("LoadTasks: {0}", ex.Message));
            }

            return result;
        }

        public static List<MCrudProfil> LoadCrudProfils(User user, List<MCrudProfil> result)
        {
            try
            {
                using TaskManagerContext context = new();
                if(user.UsersCrudProfils != null && user.UsersCrudProfils.Count > 0)
                {
                    foreach (UsersCrudProfil item in user.UsersCrudProfils)
                    {
                        CrudProfil crudProfil = context.CrudProfils.Find(item.ProfilId);

                        if(crudProfil != null && !crudProfil.ProfilId.Equals(0))
                        {
                            MCrudProfil mCrudProfil = new(crudProfil);

                            result.Add(mCrudProfil);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("LoadCrudProfils: {0}", ex.Message));
            }

            return result;
        }

        public static IEnumerable<MTask> GetAllTasks()
        {
            List<MTask> result = new();

            try
            {
                using TaskManagerContext context = new();

                if(context.Tasks.Count() > 0)
                {
                    foreach(Tasks item in context.Tasks.OrderBy(t => t.TaskId))
                    {
                        MTask mTask = new(item);
                        result.Add(mTask);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("GetAllTasks: {0}", ex.Message));
            }

            return result.AsEnumerable();
        }
    }
}
