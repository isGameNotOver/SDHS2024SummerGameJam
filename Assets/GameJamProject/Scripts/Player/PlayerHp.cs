using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public bool healPossibility = false;
    [SerializeField] float healValue;
    [SerializeField] int healNumber = 3;

    WaitForSeconds second = new WaitForSeconds(1f);
    WaitForSeconds waitTime = new WaitForSeconds(3f);

    [SerializeField] Image hpBar;

    [SerializeField] float maxHp;
    public float curHp;

    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        if(healPossibility && Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(Heal());
        }
    }

    public void Damaged(float damage)
    {
        curHp -= damage;

        if(curHp <= 0)
        {
            curHp = 0;
            Death();
        }
        hpBar.fillAmount = curHp / maxHp;
    }

    private void Death()
    {
        LoadSceneManager.LoadScene("00.Title");
    }

    IEnumerator Heal()
    {
        int count = 0;
        while (count < healNumber && gameObject.activeSelf)
        {
            count++;
            curHp += healValue;
            if (curHp > maxHp)
            {
                curHp = maxHp;
            }
            hpBar.fillAmount = curHp / maxHp;
            yield return second;
        }

        yield return waitTime;

        healPossibility = true;
    }
}
