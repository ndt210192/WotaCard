using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInitiate : MonoBehaviour
{
    [SerializeField] Transform cardField;
    [SerializeField] GameObject card;
    [SerializeField] int cardQty = 9;


    private void Awake()
    {
        for (int i = 0; i < cardQty; i++)
        {
            GameObject cardInstance = Instantiate(card);
            cardInstance.name = "" + i;
            cardInstance.transform.SetParent(cardField, false);
        }
    }
}
