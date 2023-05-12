using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSlotTrigger : MonoBehaviour
{
    [SerializeField] public bool aceD = false;

    private void OnTriggerStay(Collider card)
    {
        if (card.CompareTag("aceD"))
        {
            aceD = true;
        }
    }

    private void OnTriggerExit(Collider card)
    {
        if (card.CompareTag("aceD"))
        {
            aceD = false;
        }
    }
}
