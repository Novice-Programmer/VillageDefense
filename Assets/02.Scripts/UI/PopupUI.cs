using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class PopupUI : TObject
{
    [Header("PopupUI")]
    protected bool m_IsInit;
    protected string m_PopupDataJson;

    protected override void OnObjectActive()
    {
        base.OnObjectActive();

        if(!m_IsInit)
        {
            InitUI();
        }

        UpdateUI();
    }

    protected override void OnObjectDisable()
    {
        base.OnObjectDisable();
    }

    public void OpenPopup(string popupDataJson)
    {
        m_PopupDataJson = popupDataJson;
        ActiveObject_UniTask().Forget();
    }

    public void UpdatePopup(string popupDataJson)
    {
        m_PopupDataJson = popupDataJson;
        UpdateUI();
    }

    public void ClosePopup()
    {
        DisableObject_UniTask().Forget();
    }

    protected virtual void InitUI()
    {
        m_IsInit = true;
    }

    protected virtual void UpdateUI()
    {

    }
}
