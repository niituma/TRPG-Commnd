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
    /// ��������UI�ŕ\�����鏈���@���ʂ�value�b��ɕ\��
    /// </summary>
    /// <param name="rate">������</param>
    /// <param name="value">���ʒl</param>
    /// <param name="time">���ʕ\������</param>
    public void RateJudgeView(float rate, float value,float time)
    {
        _text.text = $"������:{rate} �� ";
        DOTween.Sequence()
            .AppendInterval(time)
            .AppendCallback(() =>
            {
                _text.text += $"{value}";
            });
    }
}
