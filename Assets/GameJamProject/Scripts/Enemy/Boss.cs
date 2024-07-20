using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject boxcoilder;
    private void Update()
    {
        PlayerTracking(playerCheckRange);

        IEnumerator Cor_Attack()
        {
            boxcoilder.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            boxcoilder.SetActive(false);
        }
    }
}
