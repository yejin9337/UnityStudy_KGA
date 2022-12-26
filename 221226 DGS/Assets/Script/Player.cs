using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 4;
    [SerializeField] private int _power = 10;
    [SerializeField] private int _maxHP = 100;

    private float _actGauge = 0;
    private int _currentHP;

    // UI 관련
    private TextMeshProUGUI _text;
    [SerializeField] private Slider _hpSlider;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Init();
    }

    private void Update()
    {
        _actGauge = Time.deltaTime * _speed;

        if(_actGauge > 100)
        {
            Time.timeScale = 0;
            if(Input.GetKeyDown(KeyCode.Space))
            { 
                Time.timeScale = 1;
                Attack();
            }
        }
    }

    private void Attack()
    {
        Debug.Log($"{this.gameObject.name} 의 공격!");

        // 상대방의 OnDamaged 호출하기


        // 나의 행동 게이지 0으로 만들기
        _actGauge = 0;
    }

    private void OnDamaged(int damege)
    {
        _currentHP = _currentHP - damege;
        _hpSlider.value = _currentHP * 0.01f;
        _text.text = damege.ToString();

        if(_currentHP <= 0)
        {
            Debug.Log($"{this.gameObject.name} 가 죽었다");
            gameObject.SetActive(false);
        }
    }

    private void Init()
    {
        _currentHP = _maxHP;
        _actGauge = 0;
    }

}
