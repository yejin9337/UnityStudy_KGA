using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : Player
{
    private new void Awake()
    {
        base.Awake();
    }

    private new void Update()
    {
        base.Update();
    }

    protected override void FirstSkill()
    {
        _damage = (int)Mathf.Round(_power * 1.3f);
        _currentFirstSkillCoolTime = _firstSkillCoolTime;
    }

    protected override void SecondSkill()
    {
        _damage = (int)Mathf.Round(_power * 0.9f);
        _enemy.OnDamaged(_damage);
        _currentSecondSkillCoolTime = _secondSkillCoolTime;
    }
}
