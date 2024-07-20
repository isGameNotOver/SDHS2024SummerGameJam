using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderBGM;
    [SerializeField] private Slider sliderSFX;

    [SerializeField] float volumeMaster;
    [SerializeField] float volumeBGM;
    [SerializeField] float volumeSFX;

    [SerializeField] float conditioningValue = 80f;

    public AudioMixer audioMixer;

    public void Master_Volume()
    {
        volumeMaster = sliderMaster.value;
        AudioManager.audioManagerInstance.volumeMaster = (volumeMaster + conditioningValue) / conditioningValue; // ����ġ�� -80�� 0���� �ٲٱ� ���� 80�� ���ϰ� 0~1�� �Ǽ��� ����� ���� 80�� ��������.

        if (volumeMaster == sliderMaster.minValue)
        {
            volumeMaster = -conditioningValue;
            audioMixer.SetFloat("Master", -conditioningValue); // ���Ұ�
        }
        else audioMixer.SetFloat("Master", volumeMaster);
    }

    public void BGM_Volume()
    {
        volumeBGM = sliderBGM.value;
        AudioManager.audioManagerInstance.volumeBGM = (volumeBGM + conditioningValue) / conditioningValue; // ����ġ�� -80�� 0���� �ٲٱ� ���� 80�� ���ϰ� 0~1�� �Ǽ��� ����� ���� 80�� ��������.

        if (volumeBGM == sliderBGM.minValue)
        {
            volumeBGM = -conditioningValue;
            audioMixer.SetFloat("BGM", -conditioningValue); // ���Ұ�
        }
        else audioMixer.SetFloat("BGM", volumeBGM);
    }

    public void SFX_Volume()
    {
        volumeSFX = sliderSFX.value;
        AudioManager.audioManagerInstance.volumeSFX = (volumeSFX + conditioningValue) / conditioningValue; // ����ġ�� -80�� 0���� �ٲٱ� ���� 80�� ���ϰ� 0~1�� �Ǽ��� ����� ���� 80�� ��������.

        if (volumeSFX == sliderSFX.minValue)
        {
            volumeSFX = -conditioningValue;
            audioMixer.SetFloat("SFX", -conditioningValue); // ���Ұ�
        }
        else audioMixer.SetFloat("SFX", volumeSFX);
    }
}
