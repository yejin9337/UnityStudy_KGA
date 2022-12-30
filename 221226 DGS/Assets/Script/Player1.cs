using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _power = 10;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int _defense = 0;
    [SerializeField] private Player2 _enemy;

    private int _damage { get; set; }
    private const int _firstSkillCoolTime = 3;
    private int _currentFirstSkillCoolTime = 0;
    private const int _secondSkillCoolTime = 3;
    private int _currentSecondSkillCoolTime = 0;

    private float _actGauge = 0;
    private int _currentHP;

    // UI ����
    private DamageUI _damageUI;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _actGaugeSlider;

    private void Awake()
    {
        _damageUI = GetComponentInChildren<DamageUI>();
        _hpSlider.value = 1;
        Init();
    }

    private void Update()
    {
        _actGauge += Time.deltaTime * _speed;
        _actGaugeSlider.value = _actGauge * 0.01f;

        if(_actGauge > 100)
        {
            Debug.Log($"{this.name}�� ��������");
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log($"{this.gameObject.name} �� ����!");

        _damage = 0;
        _currentFirstSkillCoolTime--;
        _currentSecondSkillCoolTime--;

        if (_currentSecondSkillCoolTime < 0)
        {
            _damage = SecondSkill();
        }
        else if (_currentFirstSkillCoolTime < 0)
        {
            _damage = FirstSkill();
        }
        else
        {
            _damage = _power;
        }

        // ������ OnDamaged ȣ���ϱ�
        _enemy.OnDamaged(_damage);

        // ���� �ൿ ������ 0���� �����
        _actGauge = 0;
    }

    private int FirstSkill()
    {
        _currentHP += (int)Mathf.Round(_maxHP * 0.2f);
        _hpSlider.value = _currentHP * 0.01f;
        _currentFirstSkillCoolTime = _firstSkillCoolTime;
        return _damage;
    }

    private int SecondSkill()
    {
        _damage = 50 + (int)Mathf.Round(_defense * 0.1f);
        _currentSecondSkillCoolTime = _secondSkillCoolTime;
        return _damage;
    }

    public void OnDamaged(int damege)
    {
        if(damege <= _defense)
        {
            return;
        }

        _currentHP = _currentHP - (damege - _defense);

        _hpSlider.value = _currentHP * 0.01f;
        _damageUI.StartEffect((damege - _defense));

        if(_currentHP <= 0)
        {
            Debug.Log($"{this.gameObject.name} �� �׾���");
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    private void Init()
    {
        _currentHP = _maxHP;
        _actGauge = 0;
    }
}