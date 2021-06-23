using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TaskManager.DAL.Data;
using TaskManager.DAL.Model;
using System.Data;

namespace TaskManager.DAL.CrudManager
{
    public class CrudManager
    {
        public static List<User> GetAllUsers()
        {
            List<User> result = new();
            SortedList<string, User> treated = new();

            try
            {
                using SqlConnection cnx = DBConnectionProvider.OpenConnection() ;
                using SqlCommand cmd = new("spGetAllUsers", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["userId"] != DBNull.Value)
                    {
                        if (!treated.ContainsKey(reader["userId"].ToString()))
                        {
                            User user = new()
                            {
                                UserIdentifier = reader.GetInt32(reader.GetOrdinal("userId")),
                                UserName = reader.GetString(reader.GetOrdinal("userName")),
                                TS = reader.GetDateTime(reader.GetOrdinal("TS")),
                                State = reader.GetString(reader.GetOrdinal("state"))
                            };

                            if(reader["profilId"] != DBNull.Value)
                            {
                                CrudProfil crudProfil = new()
                                {
                                    CrudProfilIdentifier = reader.GetInt32(reader.GetOrdinal("profilId")),
                                    Label = reader.GetString(reader.GetOrdinal("label")),
                                    TS = reader.GetDateTime(reader.GetOrdinal("TS")),
                                    State = reader.GetString(reader.GetOrdinal("state"))
                                };
                                user.CrudProfils.Add(crudProfil);
                            }
                            treated.Add(reader["userId"].ToString(), user);
                        }
                        else
                        {
                            User user = treated[reader["userId"].ToString()];

                            if(reader["profilId"] != DBNull.Value)
                            {
                                CrudProfil crudProfil = new()
                                {
                                    CrudProfilIdentifier = reader.GetInt32(reader.GetOrdinal("profilId")),
                                    Label = reader.GetString(reader.GetOrdinal("label")),
                                    TS = reader.GetDateTime(reader.GetOrdinal("TS")),
                                    State = reader.GetString(reader.GetOrdinal("state"))
                                };
                                user.CrudProfils.Add(crudProfil);
                            }
                        }
                    }
                }
                result = treated.Values.ToList();
                reader.Close();
                cnx.Close();

            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("GetAllUsers: {0}", ex.Message));
            }

            return result;
        }

        public static List<Tasks> GetAllTasks()
        {
            List<Tasks> result = new();
            SortedList<string, Tasks> treated = new();

            try
            {
                using SqlConnection cnx = DBConnectionProvider.OpenConnection();
                using SqlCommand cmd = new("spGetAllTasks", cnx);
                cmd.CommandType = CommandType.StoredProcedure;

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["taskId"] != DBNull.Value)
                    {
                        if (!treated.ContainsKey(reader["taskId"].ToString()))
                        {
                            Tasks task = new()
                            {
                                TaskIdentifier = reader.GetInt32(reader.GetOrdinal("taskId")),
                                Label = reader.GetString(reader.GetOrdinal("taskLabel")),
                                Role = reader.GetString(reader.GetOrdinal("taskRole")),
                                TS = reader.GetDateTime(reader.GetOrdinal("taskTS")),
                                State = reader.GetString(reader.GetOrdinal("taskState")),
                            };

                            if(reader["subTaskId"] != DBNull.Value)
                            {
                                SubTasks subTask = new()
                                {
                                    TaskIdentifier = reader.GetInt32(reader.GetOrdinal("subTaskId")),
                                    Label = reader.GetString(reader.GetOrdinal("subTaskLabel")),
                                    Role = reader.GetString(reader.GetOrdinal("subTaskRole")),
                                    TS = reader.GetDateTime(reader.GetOrdinal("subTaskTS")),
                                    State = reader.GetString(reader.GetOrdinal("subTaskState")),
                                };

                                task.SubTasks.Add(subTask);
                            }

                            treated.Add(reader["taskId"].ToString(), task);
                        }
                        else
                        {
                            Tasks task = treated[reader["taskId"].ToString()];

                            if (reader["subTaskId"] != DBNull.Value)
                            {
                                SubTasks subTask = new()
                                {
                                    TaskIdentifier = reader.GetInt32(reader.GetOrdinal("subTaskId")),
                                    Label = reader.GetString(reader.GetOrdinal("subTaskLabel")),
                                    Role = reader.GetString(reader.GetOrdinal("subTaskRole")),
                                    TS = reader.GetDateTime(reader.GetOrdinal("subTaskTS")),
                                    State = reader.GetString(reader.GetOrdinal("subTaskState")),
                                };

                                task.SubTasks.Add(subTask);
                            }
                        }
                    }
                }
                result = treated.Values.ToList();
                reader.Close();
                cnx.Close();

            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("GetAllTasks: {0}", ex.Message));
            }

            return result;
        }

        
    }
}
