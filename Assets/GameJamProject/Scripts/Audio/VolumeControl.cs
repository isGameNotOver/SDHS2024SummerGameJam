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
       
        if (volumeSFX == sliderSFX.minValue)
        {
            volumeSFX = -conditioningValue;
            audioMixer.SetFloat("SFX", -conditioningValue); // ���Ұ�
        }
        else audioMixer.SetFloat("SFX", volumeSFX);
    }
}
