using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    string _text;
    [SerializeField]
    TextMeshProUGUI _textMeshPro;
    [SerializeField]
    float _nextWordIntervalTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeText(_text));
    }

    IEnumerator TypeText(string text)
    {
        _textMeshPro.text = "";
        foreach (var t in text)
        {
            _textMeshPro.text += t;
            yield return new WaitForSeconds(_nextWordIntervalTime);
        }

        yield return null;
    }
}
