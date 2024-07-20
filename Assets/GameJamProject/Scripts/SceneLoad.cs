using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] string sceneName;


    public void LoadScene()
    {
        if (sceneName == null) { return; }

        LoadSceneManager.LoadScene(sceneName);
    }
}
