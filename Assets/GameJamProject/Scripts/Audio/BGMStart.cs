using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStart : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    void Start()
    {
        AudioManager.Instance.PlayBGM(audioClip);
    }
}
