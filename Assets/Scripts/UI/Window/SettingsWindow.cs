using Assets.Localization.Interfaces;
using Assets.Scripts.UI.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField]
    private Toggle _russianLanguageToggle;
    [SerializeField]
    private Toggle _englishLanguageToggle;
    [SerializeField]
    private Toggle _spanishLanguageToggle;

    [Inject]
    ILocalizationManager _localizationManager;

    private void Start()
    {
        Dictionary<SystemLanguage, Toggle>  languageToggles = new()
        {
            { SystemLanguage.Russian, _russianLanguageToggle },
            { SystemLanguage.English, _englishLanguageToggle },
            { SystemLanguage.Spanish, _spanishLanguageToggle },
        };

        languageToggles[_localizationManager.CurrentLanguage].isOn = true;
    }

    public void LanguageChangedToRussian(bool on) => _localizationManager.ChangeLanguage(SystemLanguage.Russian);
    public void LanguageChangedToEnglish(bool on) => _localizationManager.ChangeLanguage(SystemLanguage.English);
    public void LanguageChangedToSpanish(bool on) => _localizationManager.ChangeLanguage(SystemLanguage.Spanish);

    public void CloseButtonClick()
    {
        Destroy(gameObject);
    }
}
