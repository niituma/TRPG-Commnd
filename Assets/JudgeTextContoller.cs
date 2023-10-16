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
    /// ��������UI�ŕ\�����鏈���@���ʂ�value�b��ɕ\��
    /// </summary>
    /// <param name="rate">������</param>
    /// <param name="value">���ʒl</param>
    /// <param name="time">���ʕ\������</param>
    public void RateJudgeView(float rate, float value,float time)
    {
        _canvas.alpha = 1;

        _text.text = $"������:{rate} �� ";
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
