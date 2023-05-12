using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPuzzleTracker : MonoBehaviour
{
    [SerializeField] private FirstSlotTrigger FST;
    [SerializeField] private SecondSlotTrigger SST;
    [SerializeField] private ThirdSlotTrigger TST;

    [Header("Audio Stuff")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip solvedSound;

    // Update is called once per frame
    void Update()
    {
        if (FST.aceD && SST.kingH && TST.twoS)
        {
            GameManager.Instance.cardTask.puzzleSolved = true;
            source.PlayOneShot(solvedSound);
        }
    }
}
