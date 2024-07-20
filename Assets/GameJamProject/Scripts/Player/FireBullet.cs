using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] float bulletDeathTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Co_BulletMove());
    }

    IEnumerator Co_BulletMove()
    {
        float timer = bulletDeathTime;

        while (gameObject.activeSelf && timer > 0)
        {
            float z = transform.rotation.eulerAngles.z - 45;
            Vector2 direction = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad), Mathf.Sin(z * Mathf.Deg2Rad));
            GetComponent<Rigidbody2D>().velocity = direction * speed;

            timer -= Time.deltaTime;

            yield return null;
        }

        animator.SetTrigger("End");
    }

    void DestroyBullet()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
