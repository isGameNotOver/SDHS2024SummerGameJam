using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform background;  // 배경 이미지의 Transform
    public float parallaxEffect;  // 패럴랙스 효과 비율
    public Vector3 offset;        // 카메라와 배경 사이의 오프셋

    private Transform cam;        // 메인 카메라의 Transform
    private Vector3 lastCamPosition;  // 이전 프레임의 카메라 위치

    void Start()
    {
        // 메인 카메라의 Transform 가져오기
        cam = Camera.main.transform;
        // 초기 카메라 위치 설정
        lastCamPosition = cam.position;
    }

    void Update()
    {
        // 카메라 이동 거리 계산 (x축만)
        float deltaMovementX = cam.position.x - lastCamPosition.x;

        // 배경의 새로운 위치 계산 (카메라 x축 이동 거리 * 패럴랙스 비율)
        float newBackgroundX = background.position.x + deltaMovementX * parallaxEffect;

        // 배경 위치 설정 (x축만 이동, y축은 고정)
        background.position = new Vector3(newBackgroundX, background.position.y, background.position.z) + offset;

        // 이전 프레임의 카메라 위치 업데이트
        lastCamPosition = cam.position;
    }
}
