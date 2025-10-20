using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : Singletone<PopupManager>
{
    private Transform PopupCanvasTransform;
    private readonly Dictionary<PopupHelper.EPopupName, PopupUI> PopupUIs = new();

    private void SetPopupCanvas(PopupUI popupUI)
    {
        if (PopupCanvasTransform == null)
        {
            var canvasObject = new GameObject
            {
                name = gameObject.name,
                layer = LayerMask.NameToLayer(Names.LAYERMASK_UI)
            };

            var canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
            canvas.sortingLayerName = Names.SORTINGLAYER_POPUP;
            canvas.sortingOrder = 0;

            var canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;

            canvasObject.AddComponent<GraphicRaycaster>();
            canvasObject.transform.SetParent(transform);
            PopupCanvasTransform = canvasObject.transform;
        }

        popupUI.transform.SetParent(PopupCanvasTransform, false);
    }

    private async UniTask OpenPopup_UniTask(PopupHelper.EPopupName popupName, string popupDataJson)
    {
        if (!PopupUIs.ContainsKey(popupName))
        {
            var addressableKey = PopupHelper.GetPopupAddressableKey(popupName);
            PopupUIs[popupName] = await ObjectManager.Instance.GetTObject_UniTask<PopupUI>(addressableKey);
        }

        var popupUI = PopupUIs[popupName];
        if (popupUI.IsOn)
        {
            popupUI.UpdatePopup(popupDataJson);
            return;
        }

        SetPopupCanvas(popupUI);
        popupUI.OpenPopup(popupDataJson);
    }

    public void OpenPopup(PopupHelper.EPopupName popupName, string popupDataJson) => OpenPopup_UniTask(popupName, popupDataJson).Forget();
}
