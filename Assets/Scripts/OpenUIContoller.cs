using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUIContoller : MonoBehaviour
{
    [SerializeField] CanvasGroup _charaPalams;

    [SerializeField] CanvasGroup _selectButtons;
    [SerializeField] Button _attackButton;
    [SerializeField] Button _actionButton;
    [SerializeField] JudgeTextContoller _charaJudgeBar;
    [SerializeField] JudgeTextContoller _enemyJudgeBar;

    private void Start()
    {
        _charaJudgeBar.Canvas.alpha = 0;
        _enemyJudgeBar.Canvas.alpha = 0;
    }

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

    public void RateJudge(float a, float b, float time, CharacterController chara)
    {
        if (chara is ExplorerController)
        {
            _charaJudgeBar.Canvas.alpha = 1;
            _charaJudgeBar.RateJudgeView(a, b, time);
        }
        else if (chara is EnemyController)
        {
            _enemyJudgeBar.Canvas.alpha = 1;
            _enemyJudgeBar.RateJudgeView(a, b, time);
        }
    }
}
