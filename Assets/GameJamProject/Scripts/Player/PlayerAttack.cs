using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private Transform player;

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    private bool isAttack;

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(player.rotation.y < 0)
            {
                var go = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                go.GetComponent<BulletMovement>().SetDirection(Vector2.right);
            }
            else
            {
                var go = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                go.GetComponent<BulletMovement>().SetDirection(Vector2.left);
            }
        }
    }
}

