using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgeTextContoller : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    CanvasGroup _canvas;

    private void Awake()
    {
        _canvas = GetComponent<CanvasGroup>();
        _canvas.alpha = 0;
    }

    /// <summary>
    /// 成功率をUIで表示する処理　結果はvalue秒後に表示
    /// </summary>
    /// <param name="rate">成功率</param>
    /// <param name="value">結果値</param>
    /// <param name="time">結果表示時間</param>
    public void RateJudgeView(float rate, float value,float time)
    {
        _canvas.alpha = 1;

        _text.text = $"成功率:{rate} ≧ ";
        DOTween.Sequence()
            .AppendInterval(time)
            .AppendCallback(() =>
            {
                _text.text += $"{value}";
            });
    }

    public void ViewHidden()
    {
        _canvas.alpha = 0;
    }
}
