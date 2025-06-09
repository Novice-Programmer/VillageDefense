public class PopupEnum
{
    public enum EPopupName
    {
        Loading = 0,
        Login = 1,
    }

    public static string GetPopupAddressableKey(EPopupName popupName)
    {
        return popupName switch
        {
            _ => popupName.ToString(),
        };
    }

    public static string GetPopupTitle(EPopupName popupName)
    {
        return popupName switch
        {
            _ => popupName.ToString(),
        };
    }
}
