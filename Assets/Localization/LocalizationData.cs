using UnityEngine;

[CreateAssetMenu(fileName = "Localization", menuName = "Localization/Data")]
public class LocalizationData : ScriptableObject
{
    [System.Serializable]
    public struct Entry
    {
        public string key;
        public string text;
    }

    public SystemLanguage Language;
    public Entry[] Entries;
}
