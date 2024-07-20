using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : HpBar
{
    public bool healPossibility = false;
    [SerializeField] float healValue;
    [SerializeField] int healNumber = 3;

    WaitForSeconds second = new WaitForSeconds(1f);
    WaitForSeconds waitTime = new WaitForSeconds(3f);

    private void Start()
    {
        hpBarRect = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        curHp = maxHp;
    }

    private void Update()
    {
        SetHpBar();

        if(Input.GetKeyDown(KeyCode.D) && healPossibility)
        {
            StartCoroutine(Co_Heal());
        }
    }

    protected override void Death()
    {
        base.Death();
    }

    IEnumerator Co_Heal()
    {
        healPossibility = false;

        int count = 0;

        while(gameObject.activeSelf && count < healNumber)
        {
            curHp += healValue;
            if (curHp > maxHp) { curHp = maxHp; }
            count--;
            yield return second;
        }

        yield return waitTime;

        healPossibility = true;
    }
}
