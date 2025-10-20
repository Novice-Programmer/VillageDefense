using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PopupUI : TObject
{
    [Header("PopupUI")]
    [SerializeField] protected TextMeshProUGUI Title_Text;
    [SerializeField] protected Button Close_Btn;

    [SerializeField] protected PopupHelper.EPopupName PopupName;
    [SerializeField] protected bool IsViewCloseBtn;

    protected bool m_IsInit;
    protected string m_PopupDataJson;

    private void Awake()
    {
        OnAwake();
    }


    protected override void OnObjectActive()
    {
        base.OnObjectActive();

        if(!m_IsInit)
        {
            InitUI();
        }

        UpdateUI();
    }

    protected override void OnObjectDisactive()
    {
        base.OnObjectDisactive();
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
        DisactiveObject_UniTask().Forget();
    }

    protected virtual void OnAwake()
    {
        Close_Btn.onClick.AddListener(ClosePopup);
    }

    protected virtual void InitUI()
    {
        m_IsInit = true;
        Title_Text.text = PopupHelper.GetPopupTitle(PopupName);
        Close_Btn.gameObject.SetActive(IsViewCloseBtn);
    }

    protected virtual void UpdateUI()
    {

    }
}
