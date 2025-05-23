using UnityEngine;

[CreateAssetMenu(fileName = "VillageScriptable", menuName = "Scriptable Objects/VillageScriptable")]
public class VillageScriptable : ScriptableObject
{
    public int Stage;
    public string VillageName;
    public string Description;
    public Sprite Picture;
    public StageScriptable StageScriptable;
}
