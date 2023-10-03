using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgeTextContoller : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;
    public CanvasGroup Canvas { get; private set; }

    private void Awake()
    {
        Canvas = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// 成功率をUIで表示する処理　結果はvalue秒後に表示
    /// </summary>
    /// <param name="rate">成功率</param>
    /// <param name="value">結果値</param>
    /// <param name="time">結果表示時間</param>
    public void RateJudgeView(float rate, float value,float time)
    {
        _text.text = $"成功率:{rate} ≧ ";
        DOTween.Sequence()
            .AppendInterval(time)
            .AppendCallback(() =>
            {
                _text.text += $"{value}";
            });
    }
}
