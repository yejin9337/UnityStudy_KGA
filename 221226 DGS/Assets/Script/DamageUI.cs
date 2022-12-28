using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Color _color;
    private Vector2 _position;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _color = new Color(0,0,0,0);
        _position = transform.position;
    }

    public void StartEffect(int damage)
    {
        transform.position = _position;

        _text.text = damage.ToString();
        _text.enabled = true;
        StartCoroutine(CoOnDamege());
    }

    private IEnumerator CoOnDamege()
    {
        float elapsedTime = 0;
        int delay = 2;
        _color.a = 1f;
     
        while(elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            _text.color = _color;

            _color.a = 1f - elapsedTime / delay;
            yield return null;
        }
        _text.enabled = false;
    }
}
