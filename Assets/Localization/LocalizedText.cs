using Assets.Localization.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField] 
    private string _key;

    [SerializeField] 
    private bool _updateOnLanguageChange = false;

    private TMP_Text _text;

    [Inject]
    ILocalizationManager _localizationManager;

    void Start()
    {
        _text = GetComponent<TMP_Text>();
        UpdateText();

        if (_updateOnLanguageChange)
            _localizationManager.OnLanguageChanged += UpdateText;
    }

    private void UpdateText()
    {
        if (_text != null && !string.IsNullOrEmpty(_key))
            _text.text = _localizationManager.Get(_key);
    }


    private void OnDestroy()
    {
        if (_updateOnLanguageChange)
            _localizationManager.OnLanguageChanged -= UpdateText;
    }
}
