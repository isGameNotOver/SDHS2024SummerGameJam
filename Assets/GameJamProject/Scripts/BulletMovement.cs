using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletMoveSpeed = default;

    private Vector2 direction;

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Update()
    {
        transform.position += (Vector3)direction * bulletMoveSpeed * Time.deltaTime;
        Destroy(gameObject, 0.8f);
    }

}
