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
            // ���� �÷��̾��� Euler ������ ������.
            Vector3 euler = transform.rotation.eulerAngles;

            quaternion = bullet.transform.rotation;

            // �÷��̾��� y�� ȸ�� ���� �Ҹ��� ȸ�� ���ʹϾ� ����
            quaternion = Quaternion.Euler(quaternion.eulerAngles.x, quaternion.eulerAngles.y, euler.y);

            Instantiate(bullet, firePoint.position, quaternion);
        }
    }
}
