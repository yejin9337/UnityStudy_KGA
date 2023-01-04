using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    //
    [SerializeField] private GameObject clearCube;
    [SerializeField] private GameObject greenCube;
    [SerializeField] private GameObject blueCube;
    [SerializeField] private GameObject blackCube;
    private GameObject installObj;
    
    void Awake()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            installObj = clearCube;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            installObj = greenCube;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            installObj = blueCube;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            installObj = blackCube;
        }
        else
        {
            installObj = null;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(installObj == null)
            {
                return;
            }

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject hitObject = hit.transform.gameObject;
            //install
            Vector3 pos = hit.point;
            Vector3 vector3 = Vector3.zero;
            vector3.x = Mathf.Round(pos.x) / 100;
            vector3.z = (int)Mathf.Round(pos.y) / 100;

            if (hitObject.tag == "Ground")
            {
                Instantiate(installObj, (vector3 * 50), Quaternion.identity);
            }
            else if (hitObject.tag == "Cube")
            {
                Destroy(hitObject.gameObject);
                Instantiate(installObj, (vector3 * 50), Quaternion.identity);
            }
            else
            {
                return;
            }
        }
    }
}
