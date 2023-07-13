using UnityEngine;

public class AlwaysOnScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Screen.sleepTimeout = SleepTimeout.NeverSleep; 
    }
}
