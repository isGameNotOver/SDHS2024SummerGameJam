using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public static StatManager instance = null;

    public Slider hpBar;
    public float playerMaxHp;
    [SerializeField] private float playerCurHp;

    public float PlayerCurHp
    {
        get { return hpBar.value; }
        set
        {
            if (!moojuck && playerCurHp > value)
            {
                playerCurHp = value;
                StartCoroutine(SetMoojuck());
            }
            else if (playerCurHp <= value)
            {
                playerCurHp = value;
            }

            if (playerCurHp > playerMaxHp)
            {
                playerCurHp = playerMaxHp;
            }
        }
    }

    private bool moojuck = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }

        hpBar.maxValue = playerMaxHp;
        hpBar.minValue = 0;
        hpBar.value = playerCurHp;
    }
    private void Update()
    {
        if (playerCurHp > playerMaxHp)
        {
            playerCurHp = playerMaxHp;
        }

        hpBar.value = playerCurHp;
    }

    IEnumerator SetMoojuck()
    {
        moojuck = true;
        var playerSP = FindObjectOfType<PlayerMovement>().GetComponent<SpriteRenderer>();
        playerSP.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        playerSP.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        playerSP.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        playerSP.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        playerSP.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        playerSP.color = Color.white;
        moojuck = false;
    }
}
