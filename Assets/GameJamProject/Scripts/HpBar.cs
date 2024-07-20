using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] protected Transform barMaster; // 플레이어의 Transform을 참조
    [SerializeField] protected RectTransform hpBarRect; // HP 바의 RectTransform을 참조
    [SerializeField] protected Image barImage;
    [SerializeField] protected Vector3 offset; // HP 바가 플레이어 위에 위치하도록 오프셋 설정

    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;

    protected virtual void SetHpBar()
    {
        if (barMaster != null)
        {
            // 플레이어의 월드 좌표를 화면 좌표로 변환
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(barMaster.position + offset);

            // HP 바의 위치를 업데이트
            hpBarRect.position = screenPosition;

            barImage.fillAmount = curHp / maxHp;

            if (curHp <= 0)
            {
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        Destroy(barMaster.gameObject);
        Destroy(gameObject);
    }
}