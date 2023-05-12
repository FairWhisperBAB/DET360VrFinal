using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumPadBtn : MonoBehaviour
{
    [SerializeField] TMP_Text EnterTxt;

    [Header("Audio Stuff")]
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip solvedSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("1"))
            EnterTxt.text += "1";
        else if (other.CompareTag("2"))
            EnterTxt.text += "2";
        else if (other.CompareTag("3"))
            EnterTxt.text += "3";
        else if (other.CompareTag("4"))
            EnterTxt.text += "4";
        else if (other.CompareTag("5"))
            EnterTxt.text += "5";
        else if (other.CompareTag("6"))
            EnterTxt.text += "6";
        else if (other.CompareTag("7"))
            EnterTxt.text += "7";
        else if (other.CompareTag("8"))
            EnterTxt.text += "8";
        else if (other.CompareTag("9"))
            EnterTxt.text += "9";
        else if (other.CompareTag("0"))
            EnterTxt.text += "0";
        else if (other.CompareTag("C"))
            EnterTxt.text = "";
    }

    private void Update()
    {
        if (EnterTxt.text == "10")
        {
            StartCoroutine(WaitForDeadTime());
            EnterTxt.text = ":)";
            GameManager.Instance.codeTask.puzzleSolved = true;
            source.PlayOneShot(solvedSound);
        }
    }

    IEnumerator WaitForDeadTime()
    {
        yield return new WaitForSeconds(5);
    }
}