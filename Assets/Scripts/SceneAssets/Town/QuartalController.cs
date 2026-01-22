using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuartalController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _description;

    [SerializeField]
    private GameObject _contentWindow;


    private Vector3 _SelectionScaleFactor = new Vector3(1.1f, 1.1f, 1);
    private void OnMouseEnter()
    {
        transform.localScale = _SelectionScaleFactor;
        _description.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        transform.localScale = Vector3.one;
        _description.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        transform.localScale = Vector3.one;
        _description.gameObject.SetActive(false);        
        _contentWindow?.SetActive(true);
    }    

}
