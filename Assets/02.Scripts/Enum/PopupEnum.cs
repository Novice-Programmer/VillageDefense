public class PopupEnum
{
    public enum EPopupName
    {
        Loading = 0,

    }

    public static string GetPopupAddressableKey(EPopupName popupName)
    {
        return popupName switch
        {
            _ => popupName.ToString(),
        };
    }
}
