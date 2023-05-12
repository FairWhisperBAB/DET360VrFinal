using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject sceneTransition;

    [Space]

    [Header("Audio Stuff")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip teleportSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            StartCoroutine(WaitToPlaySFX());
            sceneTransition.SetActive(true);
            Destroy(GameManager.Instance.gameObject);
        }
    }

    IEnumerator WaitToPlaySFX()
    {
        source.PlayOneShot(teleportSound);
        yield return new WaitForSeconds(1f);
    }

}
