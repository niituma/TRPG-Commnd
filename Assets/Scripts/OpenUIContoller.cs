using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUIContoller : MonoBehaviour
{
    [SerializeField] CanvasGroup _charaPalams;

    /// <summary>
    /// à¯êîÇÃCanvasGroupÇÃê›íËÇ∑ÇÈ
    /// </summary>
    /// <param name="canvasGroup"></param>
    /// <param name="alpha"></param>
    /// <param name="interactable"></param>
    /// <param name="blocksRaycasts"></param>
    public void SetCanvasUI(CanvasGroup canvasGroup, float alpha, bool interactable, bool blocksRaycasts)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = blocksRaycasts;
    }
    public void SetCanvasUI(CanvasGroup canvasGroup, float alpha, bool interactable)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = interactable;
    }
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
