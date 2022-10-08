using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color defaultColor;
    void Awake()
    {
        defaultColor = meshRenderer.material.color;
    }

    public void OnDamage()
    {
        Debug.Log("¾ÆÆÄ¿ë¤Ð¤Ð");
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material.color = defaultColor;
    }
}
