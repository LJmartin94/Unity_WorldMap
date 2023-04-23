using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainGeneration;

public class LoadingManager : MonoBehaviour
{
    [Header("References")]
    //public LoadScreen loadingScreen;
    public MeshLoader oceanLoader;


    //Task class
    public class LoadTask
    {
        public System.Action task;
        public string taskName;

        //Constructor
        public LoadTask(System.Action task, string name)
        {
            this.task = task;
            this.taskName = name;
        }

        public long Execute()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            task.Invoke();
            return sw.ElapsedMilliseconds;
        }
    }


    //Set this to be called before all others in script execution order settings
    void Awake()
    {
        Load();
    }

    void Load()
    {
        LoadTask[] tasks = GetTasks();
    }

    public LoadTask[] GetTasks()
    {
        List<LoadTask> taskList = new List<LoadTask>();

        void AddTasks(System.Action task, string name)
        {
            taskList.Add(new LoadTask(task, name));
        }
        
        //Tasks go here:
        //AddTask();
        
        return taskList.ToArray();
    }
}