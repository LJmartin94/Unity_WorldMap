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

        public long Execute(bool log = false /*, LoadScreen loadingScreen*/)
        {
            if (log)
            {
                //loadingScreen.Log(taskName, newLine: true);
                var sw = System.Diagnostics.Stopwatch.StartNew();
                task.Invoke();
                //loadingScreen.Log($" {sw.ElapsedMilliseconds}ms.", newLine: false);
                return sw.ElapsedMilliseconds;
            }
            task.Invoke();
            return 0;
        }
    }


    //Set this to be called before all others in script execution order settings
    void Awake()
    {
        Load();
    }

    void Load()
    {
        LoadTask[] tasks;
    }
}