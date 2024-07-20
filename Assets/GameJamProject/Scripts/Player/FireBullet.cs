using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //void BulletMove()
    //{
    //    float z = transform.rotation.eulerAngles.z;
    //    Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
    //    GetComponent<Rigidbody2D>().velocity = direction * speed;
    //}

    public void Init(Vector3 direction, float speed)
    {
        rigid.velocity = direction * speed;
    }
}
