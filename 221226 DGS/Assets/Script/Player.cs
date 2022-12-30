using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    [Header("캐릭터 스탯 설정")]
    [SerializeField] protected int _speed;
    [SerializeField] protected int _power;
    [SerializeField] protected int _defense;
    [SerializeField] protected int _maxHP;

    [Header("스킬 쿨타임")]
    [SerializeField] protected int _firstSkillCoolTime;
    [SerializeField] protected int _secondSkillCoolTime;
    protected int _currentFirstSkillCoolTime = 0;
    protected int _currentSecondSkillCoolTime = 0;

    [Header("적 설정")]
    [SerializeField] protected Player _enemy;

    [Header("UI 설정")]
    [SerializeField] protected DamageUI _damageUI;
    [SerializeField] protected PlayerUI _playerUI;

    protected int _damage;
    protected int _currentHP;
    protected float _actGauge;
    protected void Awake()
    {
        Init();
    }

    protected void Update()
    {
        _actGauge += Time.deltaTime * _speed;
        _playerUI.RenewActGauge(_actGauge);

        if (_actGauge > 100)
        {
            Attack();
        }
    }
    protected void Init()
    {
        _currentHP = _maxHP;
        _actGauge = 0;
    }

    protected void Attack()
    {
        _damage = 0;
        _currentFirstSkillCoolTime--;
        _currentSecondSkillCoolTime--;

        if (_currentSecondSkillCoolTime <= 0)
        {
            SecondSkill();
        }
        else if (_currentFirstSkillCoolTime <= 0)
        {
            FirstSkill();
        }
        else
        {
            _damage = _power;
        }

        // 상대방의 OnDamaged 호출하기
        _enemy.OnDamaged(_damage);

        // 나의 행동 게이지 0으로 만들기
        _actGauge = 0;
    }
    protected abstract void FirstSkill();
    protected abstract void SecondSkill();

    public void OnDamaged(int damage)
    {
        if (damage <= _defense)
        {
            _damageUI.StartEffect(0);
            return;
        }

        _currentHP -= damage - _defense;
        _damageUI.StartEffect((damage - _defense));
        _playerUI.RenewHP(_currentHP);

        if (_currentHP <= 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

}
