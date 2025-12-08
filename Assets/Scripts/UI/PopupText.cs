using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Image _icon;
    public void Show(Vector3 position, string message, Sprite icon = null)
    {
        transform.position = position;
        _text.text = message;
        _icon.sprite = icon;
        StartCoroutine(FloatAndDestroy(gameObject));
    }

    private IEnumerator FloatAndDestroy(GameObject popup)
    {

        var startPos = popup.transform.position;
        var floatingHigh = 0.3f;
        var stepSize = 0.02f;

        while (Vector3.Distance(popup.transform.position, startPos) < floatingHigh)
        {
            popup.transform.position += Vector3.up * stepSize;

            yield return new WaitForSeconds(0.02f);
        }
        Destroy(popup);
    }
}
