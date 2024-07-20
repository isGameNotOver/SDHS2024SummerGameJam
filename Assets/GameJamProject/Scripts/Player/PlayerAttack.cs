using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Quaternion quaternion;

    public bool possibleFire;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            // 현재 플레이어의 Euler 각도를 가져옴.
            Vector3 euler = transform.rotation.eulerAngles;

            quaternion = bullet.transform.rotation;

            // 플레이어의 y축 회전 값을 불릿의 회전 쿼터니언에 적용
            quaternion = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, euler.y);

            Instantiate(bullet, firePoint.position, quaternion);
        }
    }
}
