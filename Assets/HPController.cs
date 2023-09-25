using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField]
    Slider _HPSlider;
    [SerializeField]
    float _MaxHPValue;
    [SerializeField, ReadOnly]
    BoolReactiveProperty _isdead = new BoolReactiveProperty(false);

    public bool IsDead { get => _isdead.Value; }

    float _currentHP;

    // Start is called before the first frame update
    void Start()
    {
        _currentHP = _MaxHPValue;

        _isdead.Where(x => true).Subscribe(enable =>
        {
            if (!enable)
            {
                return;
            }
            OnDead();
        }).AddTo(this);
    }

    public void Damage(float damage)
    {
        if (IsDead) { return; }
        _currentHP -= damage;
        if (_currentHP <= 0) { _isdead.Value = true; }
        _HPSlider.value = _currentHP / _MaxHPValue;
    }
    public void OnDead()
    {
        GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(() => this.gameObject.SetActive(false));
    }
}
