using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPopup : PopupUI
{
    [Header("LoginPopup")]
    [SerializeField] private TMP_InputField ID_InputField;
    [SerializeField] private TMP_InputField PW_InputField;
    [SerializeField] private Button Login_Btn;
    [SerializeField] private Button SignUp_Btn;
    [SerializeField] private TextMeshProUGUI Message_Text;
    [SerializeField] private Button FindID_Btn;
    [SerializeField] private Button FindPW_Btn;

    protected override void OnAwake()
    {
        base.OnAwake();
        Login_Btn.onClick.AddListener(OnLoginClick);
        SignUp_Btn.onClick.AddListener(OnSignUpClick);
        FindID_Btn.onClick.AddListener(OnFindIDClick);
        FindPW_Btn.onClick.AddListener(OnFindPWClick);
    }

    private void OnLoginClick()
    {

    }

    private void OnSignUpClick()
    {

    }

    private void OnFindIDClick()
    {

    }

    private void OnFindPWClick()
    {

    }
}
