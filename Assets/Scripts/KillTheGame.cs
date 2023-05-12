using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillTheGame : MonoBehaviour
{
    [SerializeField] private int killGameTimer = 61;

    private void Start()
    {
        StartCoroutine(KillGame());

    }

    IEnumerator KillGame()
    {
        yield return new WaitForSeconds(killGameTimer);
        Debug.Log("Game Quit");
        Application.Quit();
    }



}
