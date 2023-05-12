using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;
using UnityEngine.Experimental.GlobalIllumination;

[Serializable]
public class Tasks
{
    public string taskInstruction;
    public bool puzzleSolved = false;
    public TMP_Text taskTxt;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("TASKS")]
    public Tasks serverTask = new Tasks();
    public Tasks cardTask = new Tasks();
    public Tasks codeTask = new Tasks();

    [Space]

    [Header("Stuff That Changes Color")]
    [SerializeField] private GameObject[] greenProps;
    [SerializeField] private Material greenMat;

    [SerializeField] private GameObject[] whiteProps;
    [SerializeField] private Material whiteMat;

    [SerializeField] private Light[] Lights;
    [SerializeField] private Color lightColor;

    [Space]

    [Header("Triggers")]
    [SerializeField] private GameObject exitDoorBtn;
    [SerializeField] private GameObject exitSignLight;
    
    [Space]

    [SerializeField] private GameObject cardTrigger;

    [Space]

    [SerializeField] private GameObject exitTxt;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        serverTask.taskTxt.text = serverTask.taskInstruction;
        cardTask.taskTxt.text= cardTask.taskInstruction;
        codeTask.taskTxt.text = codeTask.taskInstruction;

        exitDoorBtn.SetActive(false);
        exitSignLight.SetActive(false);
        exitTxt.SetActive(false);
    }

    private void Update()
    {
        if (serverTask.puzzleSolved)
            serverTask.taskTxt.text = $"<s>{serverTask.taskInstruction}</s>";

        if (codeTask.puzzleSolved)
            codeTask.taskTxt.text = $"<s>{codeTask.taskInstruction}</s>";

        if (cardTask.puzzleSolved)
        {
            cardTask.taskTxt.text = $"<s>{cardTask.taskInstruction}</s>";
            cardTrigger.SetActive(false);
        }

        if (serverTask.puzzleSolved && codeTask.puzzleSolved && cardTask.puzzleSolved)
        {
            for (int i = 0; i < greenProps.Length; i++)
            {
                greenProps[i].GetComponent<Renderer>().material = greenMat;
            }

            for (int i = 0; i < whiteProps.Length; i++)
            {
                whiteProps[i].GetComponent<Renderer>().material = whiteMat;
            }

            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i].color = lightColor;
            }
            
            exitDoorBtn.SetActive(true);
            exitSignLight.SetActive(true);
            exitTxt.SetActive(true);
        }   
    }
}
