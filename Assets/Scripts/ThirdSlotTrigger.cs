using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSlotTrigger : MonoBehaviour
{
    [SerializeField] public bool twoS = false;

    private void OnTriggerStay(Collider card)
    {
        if (card.CompareTag("twoS"))
        {
            twoS = true;
        }
    }

    private void OnTriggerExit(Collider card)
    {
        if (card.CompareTag("twoS"))
        {
            twoS = false;
        }
    }
}
