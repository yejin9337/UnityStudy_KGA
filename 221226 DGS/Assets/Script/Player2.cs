using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private int _power = 10;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int _defense = 5;
    [SerializeField] private Player1 _enemy;

    private int _damage { get; set; }
    private const int FIRST_SKILL_COOLTIME = 2;
    private int _currentFirstSkillCoolTime = 0;
    private const int SECOND_SKILL_COOLTIME = 4;
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

        if (_actGauge > 100)
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
            SecondSkill();
        }
        else if (_currentFirstSkillCoolTime < 0)
        {
            FirstSkill();
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

    private void FirstSkill()
    {
        _damage = (int)Mathf.Round(_power * 1.3f);
        _currentFirstSkillCoolTime = FIRST_SKILL_COOLTIME;
    }

    private void SecondSkill()
    {
        _damage = (int)Mathf.Round(_power * 0.9f);
        _enemy.OnDamaged(_damage);
        _currentSecondSkillCoolTime = SECOND_SKILL_COOLTIME;
    }

    public void OnDamaged(int damege)
    {
        if (damege <= _defense)
        {
            return;
        }

        _currentHP = _currentHP - (damege - _defense);

        _hpSlider.value = _currentHP * 0.01f;
        _damageUI.StartEffect((damege - _defense));

        if (_currentHP <= 0)
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
