using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TerrainGeneration;

public class LoadingManager : MonoBehaviour
{
    public bool logTaskLoadTimes;
    public bool logTotalLoadTime;

    [Header("References")]
    //public LoadScreen loadingScreen;
    //public TerrainHeightProcessor heightProcessor;
    //public CityLights cityLights;
    //public Light sunLight;
    //public WorldLookup worldLookup;
    //public GlobeMapLoader globeMapLoader;

    //public LodMeshLoader terrainLoader;
    public MeshLoader oceanLoader;
    //public MeshLoader countryOutlineLoader;

    //unused?:
    //public Player player;
    //public TerrainHeightSettings heightSettings;
    //public AtmosphereEffect atmosphereEffect;

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
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        if (logTotalLoadTime)
            sw.Start();
        
        LoadTask[] tasks = GetTasks();

        foreach (LoadTask task in tasks)
        {
            long time = task.Execute();
            if (logTaskLoadTimes)
                Debug.Log($"{task.taskName} took {time} ms to complete.");
        }

        if (logTotalLoadTime)
            Debug.Log($"Total loading duration in ms: {sw.ElapsedMilliseconds}");
    }

    public LoadTask[] GetTasks()
    {
        List<LoadTask> taskList = new List<LoadTask>();

        void AddTasks(System.Action task, string name)
        {
            taskList.Add(new LoadTask(task, name));
        }

        //Tasks go here:

        //	AddTasks(() => heightProcessor.ProcessHeightMap(), "Processing Height Map");
        //	AddTasks(() => cityLights.Init(heightProcessor.processedHeightMap, sunLight), "Creating City Lights");
        //	AddTasks(() => worldLookup.Init(heightProcessor.processedHeightMap), "Initializing World Lookup");
        //	AddTasks(() => globeMapLoader.Load(), "Loading Globe (map)");
        //	AddTasks(() => terrainLoader.Load(), "Loading Terrain Mesh");
        AddTasks(() => oceanLoader.Load(), "Loading Ocean Mesh");
        //	AddTasks(() => countryOutlineLoader.Load(), "Loading Country Outlines");

        return taskList.ToArray();
    }
}