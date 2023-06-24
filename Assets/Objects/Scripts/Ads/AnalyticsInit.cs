using System;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsInit: MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Awake()
    {
        Analytics.initializeOnStartup = true;
        Debug.Log("Analytics Initialized");
    }
}