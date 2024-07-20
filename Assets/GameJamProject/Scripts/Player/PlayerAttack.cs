using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    public bool possibleFire;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Quaternion quaternion = bullet.transform.rotation;
            quaternion.z = transform.rotation.y;

            Instantiate(bullet, firePoint.position, quaternion);
        }
    }
}
