using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Defines.EBuffType currentBuffType;
    private Enemy currentEnemy = null;
    void Update()
    {
        if (Input.GetMouseButton(0)&& GetClickedEnemy(out currentEnemy))
        {
            switch(currentBuffType)
            {
                case Defines.EBuffType.Normal:
                    currentEnemy.TakeDamage(CSVTable.Instance.Get(Defines.TableKeys.NormalDamage));
                    break;
                default:
                    currentEnemy.AddBuff(currentBuffType);
                    break;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
            currentBuffType = Defines.EBuffType.Fire;
        
        if (Input.GetKeyDown(KeyCode.W))       
            currentBuffType = Defines.EBuffType.Posion;
        
        if (Input.GetKeyDown(KeyCode.E))
            currentBuffType = Defines.EBuffType.Curse;

        if (Input.GetKeyDown(KeyCode.R))
            currentBuffType = Defines.EBuffType.Normal;
    }

    bool GetClickedEnemy(out Enemy enemy)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            enemy = hit.transform.parent.GetComponent<Enemy>();
            return true;
        }
        else
        {
            enemy = null;
            return false;
        }
    }
}
