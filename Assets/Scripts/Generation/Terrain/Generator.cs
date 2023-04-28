using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    public enum StartupMode { DoNothing, Generate, Load }
    public StartupMode startupMode;

    //States
    public bool generationInProgress { get; private set; }
    public bool generationComplete { get; private set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        switch (startupMode)
        {
            case StartupMode.DoNothing:
                break;
            case StartupMode.Generate:
                StartGenerating();
                break;
            case StartupMode.Load:
                Load();
                break;
        }
    }

    protected void startGenerationState()
    {
        generationInProgress = true;
        generationComplete = false;
    }

    protected void stopGenerationState()
    {
        generationInProgress = false;
        generationComplete = true;
    }

    public abstract void StartGenerating();

    public abstract void Save();

    public abstract void Load();

    protected virtual string SavePath
    {
        get
        {
            return FileHelper.MakePath("Assets", "Data", "Terrain");
        }
    }
}
