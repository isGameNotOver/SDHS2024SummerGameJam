using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private Transform player;

    [SerializeField] private WaitForSeconds waitFire = new WaitForSeconds(1f);

    public bool firePossibility = false;
    public bool waterPossibility = false;

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.A) && firePossibility)
        {
            if(player.eulerAngles.y == 0)
            {
                var go = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                go.GetComponent<BulletMovement>().SetDirection(Vector2.left);
            }
            else
            {
                var go = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                go.GetComponent<BulletMovement>().SetDirection(Vector2.right);
            }

            StartCoroutine(Co_FireCooltime());
        }
    }

    IEnumerator Co_FireCooltime()
    {
        firePossibility = false;
        yield return waitFire;
        firePossibility = true;
    }
}

