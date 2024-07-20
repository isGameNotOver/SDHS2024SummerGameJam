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
        AudioManager.audioManagerInstance.volumeMaster = (volumeMaster + conditioningValue) / conditioningValue; // 최하치인 -80을 0으로 바꾸기 위해 80을 더하고 0~1의 실수를 만들기 위해 80을 나누었다.

        if (volumeMaster == sliderMaster.minValue)
        {
            volumeMaster = -conditioningValue;
            audioMixer.SetFloat("Master", -conditioningValue); // 음소거
        }
        else audioMixer.SetFloat("Master", volumeMaster);
    }

    public void BGM_Volume()
    {
        volumeBGM = sliderBGM.value;
        AudioManager.audioManagerInstance.volumeBGM = (volumeBGM + conditioningValue) / conditioningValue; // 최하치인 -80을 0으로 바꾸기 위해 80을 더하고 0~1의 실수를 만들기 위해 80을 나누었다.

        if (volumeBGM == sliderBGM.minValue)
        {
            volumeBGM = -conditioningValue;
            audioMixer.SetFloat("BGM", -conditioningValue); // 음소거
        }
        else audioMixer.SetFloat("BGM", volumeBGM);
    }

    public void SFX_Volume()
    {
        volumeSFX = sliderSFX.value;
        AudioManager.audioManagerInstance.volumeSFX = (volumeSFX + conditioningValue) / conditioningValue; // 최하치인 -80을 0으로 바꾸기 위해 80을 더하고 0~1의 실수를 만들기 위해 80을 나누었다.

        if (volumeSFX == sliderSFX.minValue)
        {
            volumeSFX = -conditioningValue;
            audioMixer.SetFloat("SFX", -conditioningValue); // 음소거
        }
        else audioMixer.SetFloat("SFX", volumeSFX);
    }
}
