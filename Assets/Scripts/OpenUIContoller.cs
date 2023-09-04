using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUIContoller : MonoBehaviour
{
    [SerializeField]
    CanvasGroup _charaPalams;
    public void OpenUI()
    {
        _charaPalams.alpha = 1.0f;
        _charaPalams.interactable = true;
        _charaPalams.blocksRaycasts = true;
    }

    public void CloseUI()
    {
        _charaPalams.alpha = 0.0f;
        _charaPalams.interactable = false;
        _charaPalams.blocksRaycasts = false;
    }
}
