//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LeftArm : MonoBehaviour
//{
//    private Defines.EWeaponType randomWeapon;
//    void Start()
//    {
//        randomWeapon = (Defines.EWeaponType)(Random.Range(0, 4)); // ����?
//    }

//    void Update()
//    {
//        Attack(randomWeapon);
//    }

//    public void Attack(Defines.EWeaponType weaponType)
//    {
//        switch (weaponType)
//        {
//            case Defines.EWeaponType.Punch:
//                break;
//            case Defines.EWeaponType.Whirlwind:
//                break;
//            case Defines.EWeaponType.Fire:
//                break;
//            case Defines.EWeaponType.Rocket:
//                break;
//            default:
//                Debug.LogError($"���ǵ��� ���� ����{weaponType}");
//                break;
//        }
//    }

//    private IEnumerator Punch()
//    {

//        yield return new WaitForSeconds(1);
//    }
//}
