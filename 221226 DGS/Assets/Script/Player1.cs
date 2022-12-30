using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
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
        _currentHP += (int)Mathf.Round(_maxHP * 0.2f);
        if(_currentHP >= _maxHP)
        {
            _currentHP = _maxHP;
        }
        _playerUI.RenewHP(_currentHP);
        _currentFirstSkillCoolTime = _firstSkillCoolTime;
    }

    protected override void SecondSkill()
    {
        _damage = 50 + (int)Mathf.Round(_defense * 0.1f);
        _currentSecondSkillCoolTime = _secondSkillCoolTime;
    }
}
