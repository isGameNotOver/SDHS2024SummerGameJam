using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

//Cinemachin ī�޶� �̿��ؼ� ī�޶� �����ϴ� ��ũ��Ʈ    
public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    private CinemachineVirtualCamera camera;
    private CinemachineBasicMultiChannelPerlin camSetting;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        camera = transform.GetChild(0).GetComponent<CinemachineVirtualCamera>();
        camSetting = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    //ī�޶� ��� �� �ְ� �Լ� ����
    private void _Shake(float time, float amplittude, float frequency)
    {   
        camSetting.m_AmplitudeGain = 0;
        camSetting.m_FrequencyGain = 0;
        StopAllCoroutines();
        StartCoroutine(StartShake(time, amplittude, frequency));
        IEnumerator StartShake(float time, float amplittude, float frequency)
        {
            camSetting.m_AmplitudeGain = amplittude;
            camSetting.m_FrequencyGain = frequency;
            yield return new WaitForSeconds(time);
            camSetting.m_AmplitudeGain = 0;
            camSetting.m_FrequencyGain = 0;
        }
    }
    public static void Shake(float time, float amplittude, float frequency) => instance._Shake(time, amplittude, frequency);
}
