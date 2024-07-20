using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : HpBar
{
    private void Start()
    {
        hpBarRect = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        curHp = maxHp;
    }
}
