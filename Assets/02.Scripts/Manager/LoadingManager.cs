using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singletone<LoadingManager>
{
    [Header("SceneLoading")]
    [SerializeField] private GameObject SceneLoadingPanel;
    [SerializeField] private Slider SceneLoadingSlider;
    [SerializeField] private TextMeshProUGUI SceneLoadingMessage;

    [Header("Loading")]
    [SerializeField] private GameObject LoadingPanel;

    private bool m_IsChange;

    public static void ChangeScene(SceneEnum.ESceneName sceneName)
    {
        if (Instance.m_IsChange)
        {
            return;
        }

        Instance.m_IsChange = true;

        Instance.ChangeScene_UniTask(sceneName).Forget();
    }

    private async UniTask ChangeScene_UniTask(SceneEnum.ESceneName sceneName)
    {
        m_IsChange = true;
        SceneLoadingPanel.SetActive(true);
        SceneLoadingSlider.value = 0;
        SceneLoadingMessage.text = $"0%";
        var asyncLoad = SceneManager.LoadSceneAsync($"{sceneName}Scene");

        while (!asyncLoad.isDone)
        {
            SceneLoadingMessage.text = $"{SceneLoadingSlider.value * 100:F0}%";
            SceneLoadingSlider.value = Mathf.Lerp(0, 1, asyncLoad.progress);

            await UniTask.Yield();
        }

        asyncLoad.allowSceneActivation = true;
        SceneLoadingPanel.SetActive(false);
        m_IsChange = false;
    }
}
