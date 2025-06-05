using Cysharp.Threading.Tasks;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartTest().Forget();
    }

    private async UniTask StartTest()
    {
        await DataManager.Instance.InitData_UniTask();
        await StageManager.Instance.InitStage_UniTask(new(0));
    }
}
