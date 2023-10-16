using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAttackUI : MonoBehaviour
{
    [SerializeField] JudgeTextContoller _charaJudgeBar;
    [SerializeField] JudgeTextContoller _enemyJudgeBar;
    public void RateJudge(float a, float b, float time, CharacterController chara)
    {
        if (chara is ExplorerController)
        {
            _charaJudgeBar.RateJudgeView(a, b, time);
        }
        else if (chara is EnemyController)
        {
            _enemyJudgeBar.RateJudgeView(a, b, time);
        }
    }

    public void ViewHiddenJudgeBar(CharacterController chara)
    {
        if (chara is ExplorerController)
        {
            _charaJudgeBar.ViewHidden();
        }
        else if (chara is EnemyController)
        {
            _enemyJudgeBar.ViewHidden();
        }
    }
}
