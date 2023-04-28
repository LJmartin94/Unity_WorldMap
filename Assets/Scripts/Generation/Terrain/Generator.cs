using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    public enum StartupMode { DoNothing, Generate, Load }
    public StartupMode startupMode;

    public bool isGenerating { get; private set; }
    public bool generationComplete { get; private set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        switch (startupMode)
        {
            case StartupMode.DoNothing:
                break;
            case StartupMode.Generate:
                break;
            case StartupMode.Load:
                break;
        }
    }
}
