using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    private float _power;
    public float Power { get { return _power; } set { _power = value; } }

    private Vector3 curDir;
    private Defines.EWeaponType leftArmWeapon;
    private Defines.EWeaponType rightArmWeapon;


    public bool CanMoving { get; set; }

    private void Awake()
    {
        curDir = Vector3.zero;
        CanMoving = false;
        _power = Random.Range(10f, 50f);
        leftArmWeapon = (Defines.EWeaponType)(Random.Range(0, 4)); // 들어가나?
        rightArmWeapon = (Defines.EWeaponType)(Random.Range(0, 4));
    }

    void Update()
    {
        if (CanMoving == false)
        {
            return;
        }

        Move();

        if(Input.GetMouseButtonDown(0))
        {
            LeftAttack();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            RightAttack();
        }
    }

    private void Move()
    {

        curDir = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            curDir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            curDir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            curDir.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            curDir.z = -1;
        }

        curDir.Normalize();

        transform.position += curDir * (moveSpeed * Time.deltaTime);
    }

    void LeftAttack()
    {
        Attack(leftArmWeapon);
    }
    void RightAttack()
    {
        Attack(rightArmWeapon);
    }
    void Attack(Defines.EWeaponType weaponType)
    {
        switch (weaponType)
        {
            case Defines.EWeaponType.Punch:
                Debug.Log("Punch");
                //Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                //foreach (Collider collider in colliders)
                //{
                //    if()
                //    enemy.OnDamage();
                //}
                StartCoroutine(Punch());
                break;

            case Defines.EWeaponType.Whirlwind:
                Debug.Log("Whirlwind");
                break;
            case Defines.EWeaponType.Fire:
                Debug.Log("Fire");
                break;
            case Defines.EWeaponType.Rocket:
                Debug.Log("Rocket");
                break;
            default:
                Debug.LogError($"정의되지 않은 무기{weaponType}");
                break;
        }
    }

    private IEnumerator Punch()
    {
        yield return new WaitForSeconds(1);
    }
}
