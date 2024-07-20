using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform background;  // ��� �̹����� Transform
    public float parallaxEffect;  // �з����� ȿ�� ����
    public Vector3 offset;        // ī�޶�� ��� ������ ������

    private Transform cam;        // ���� ī�޶��� Transform
    private Vector3 lastCamPosition;  // ���� �������� ī�޶� ��ġ

    void Start()
    {
        // ���� ī�޶��� Transform ��������
        cam = Camera.main.transform;
        // �ʱ� ī�޶� ��ġ ����
        lastCamPosition = cam.position;
    }

    void Update()
    {
        // ī�޶� �̵� �Ÿ� ��� (x�ุ)
        float deltaMovementX = cam.position.x - lastCamPosition.x;

        // ����� ���ο� ��ġ ��� (ī�޶� x�� �̵� �Ÿ� * �з����� ����)
        float newBackgroundX = background.position.x + deltaMovementX * parallaxEffect;

        // ��� ��ġ ���� (x�ุ �̵�, y���� ����)
        background.position = new Vector3(newBackgroundX, background.position.y, background.position.z) + offset;

        // ���� �������� ī�޶� ��ġ ������Ʈ
        lastCamPosition = cam.position;
    }
}
