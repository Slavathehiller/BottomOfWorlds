using Assets.Localization.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LocalizationManager : ILocalizationManager
{
    private const string KEY_LANGUAGE = "SelectedLanguage";

    public event UnityAction OnLanguageChanged;

    private Dictionary<SystemLanguage, string> _languagesPathes = new() 
    {
        {SystemLanguage.Russian,  "Localization/Russian"},
        {SystemLanguage.English,  "Localization/English"},
        {SystemLanguage.Spanish,  "Localization/Spanish"},
    };

    private LocalizationData _currentData;

    public SystemLanguage CurrentLanguage => _currentData.Language;

    public LocalizationManager()
    {
        SystemLanguage currentLanguage;
        if (PlayerPrefs.HasKey(KEY_LANGUAGE))
            currentLanguage = (SystemLanguage)PlayerPrefs.GetInt(KEY_LANGUAGE);
        else
            currentLanguage = SystemLanguage.English;

        ChangeLanguage(currentLanguage);
    }

    public void ChangeLanguage(SystemLanguage language)
    {
        var currentDataPath = _languagesPathes[language];

        _currentData = Resources.Load<LocalizationData>(currentDataPath);

        if (_currentData == null)
        {
            Debug.LogError("No localization data found!");
            return;
        }

        PlayerPrefs.SetInt(KEY_LANGUAGE, (int)language);
        PlayerPrefs.Save();

        OnLanguageChanged?.Invoke();
    }

    public string Get(string key, string fallback = "*MISSING*")
    {
        if (_currentData == null) return fallback;
        var entry = _currentData.Entries.FirstOrDefault(e => e.key == key);
        return entry.text != null ? entry.text : fallback;
    }


}
