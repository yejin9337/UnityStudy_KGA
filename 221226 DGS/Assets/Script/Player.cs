using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 4;
    [SerializeField] private int _power = 10;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private Player _enemy;


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

        // ������ OnDamaged ȣ���ϱ�
        _enemy.OnDamaged(_power);

        // ���� �ൿ ������ 0���� �����
        _actGauge = 0;
    }

    public void OnDamaged(int damege)
    {
        _currentHP = _currentHP - damege;
        _hpSlider.value = _currentHP * 0.01f;
        _damageUI.StartEffect(damege);

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
