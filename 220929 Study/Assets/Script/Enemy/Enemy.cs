using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _currentHealth = 100;
    private int _maxHealth = 100;
    public int CurrentHealth { get { return _currentHealth; } }
    public int MaxHealth { get { return _maxHealth; } }
    
    private bool _isDead = false;
    public bool IsDead { get { return _isDead; } }

    private void Awake()
    {
        _isDead = false;
        _maxHealth = _currentHealth = Random.Range(0, 10) == 0 ? 1000 : 100;
    }

    public void AddBuff(Defines.EBuffType buffType)
    {
        switch(buffType)
        {
            case Defines.EBuffType.Fire:
                break;
            case Defines.EBuffType.Posion:
                break;
            case Defines.EBuffType.Curse:
                break;
            default:
                Debug.LogError($"���ǵ��� ���� ���� Ÿ��{buffType}");
                break;
        }
    }
    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        _isDead = true;
        StartCoroutine(WaitForRebirth());
    }

    private void OnRebirth()
    {
        _isDead = false;
        _maxHealth = _currentHealth = Random.Range(0, 10) == 0? 1000 : 100;
    }

    private IEnumerator WaitForRebirth()
    {
        yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        OnRebirth();
    }

    private IEnumerator Poison()
    {
        int poisonCount = 2;
        for (int i = 0l i < poisionCount; ++i)
        {
            TakeDamage(CSVTable.Instance.Get(Defines.TableKeys.PoisonDamage));
            yield return new WaitForSeconds("");
        }
    }
    
}
