using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActivityScriptableObject", order = 1)]
public class ActivityScriptableObject : ScriptableObject
{
    public string Name;
    public string Reason;
    public float Hours;

    public string Hint;
}
