using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] protected Transform barMaster; // �÷��̾��� Transform�� ����
    [SerializeField] protected RectTransform hpBarRect; // HP ���� RectTransform�� ����
    [SerializeField] protected Image barImage;
    [SerializeField] protected Vector3 offset; // HP �ٰ� �÷��̾� ���� ��ġ�ϵ��� ������ ����

    [SerializeField] protected float maxHp;
    [SerializeField] protected float curHp;

    protected virtual void SetHpBar()
    {
        if (barMaster != null)
        {
            // �÷��̾��� ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(barMaster.position + offset);

            // HP ���� ��ġ�� ������Ʈ
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