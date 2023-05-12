using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerBtn : MonoBehaviour
{
    [Header("Audio Stuff")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip solvedSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ServerButton"))
        {
            GameManager.Instance.serverTask.puzzleSolved = true;
            source.PlayOneShot(solvedSound);
        }
    }
}
