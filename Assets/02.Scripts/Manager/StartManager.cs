using UnityEngine;

public class StartManager : MonoBehaviour
{
    private void Awake()
    {
        SetStartSetting();
    }

    private void SetStartSetting()
    {
        Application.runInBackground = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
