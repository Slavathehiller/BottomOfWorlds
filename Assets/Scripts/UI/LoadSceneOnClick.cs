using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
