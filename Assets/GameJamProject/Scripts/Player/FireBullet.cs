using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        BulletMove();
    }

    void BulletMove()
    {
        float z = transform.rotation.eulerAngles.z - 45;
        Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
