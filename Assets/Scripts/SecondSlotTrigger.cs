using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSlotTrigger : MonoBehaviour
{
    [SerializeField] public bool kingH = false;

    private void OnTriggerStay(Collider card)
    {
        if (card.CompareTag("kingH"))
        {
            kingH = true;
        }
    }

    private void OnTriggerExit(Collider card)
    {
        if (card.CompareTag("kingH"))
        {
            kingH = false;
        }
    }
}
