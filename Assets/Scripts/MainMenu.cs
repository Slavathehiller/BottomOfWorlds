using Assets.Localization.Interfaces;
using Assets.Scripts.Factories.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _UIcanvas;

    [Inject]
    protected IUIAssetFactory _assetFactory;

    public void ExitButtonScript()
    {
        Application.Quit();
    }

    public void NewGameButtonScript()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }

    public void SettingsButtonClick()
    {
        var settingsWindow = _assetFactory.CreateAsset<SettingsWindow>(_UIcanvas);
        settingsWindow.gameObject.SetActive(true);
    }
}
