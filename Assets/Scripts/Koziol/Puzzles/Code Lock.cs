using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeLock : Interactable
{
    public bool solved = false;
    [SerializeField]
    private int[] code = new int[4];
    [SerializeField]
    private InteractableDial[] Dials;

    [SerializeField] TextMeshPro displayValues;

    private void Start()
    {
        Dials = GetComponentsInChildren<InteractableDial>();
    }

    public override void Interact()
    {
        UpdateCodeText();

        if (CheckCode())
        {
            Debug.Log("Code is correct");
            foreach (InteractableDial dial in Dials)
            {
                dial.tag = "Untagged";
            }

            solved = true;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Code is incorrect");
        }
    }

    bool CheckCode()
    {
        for (int i = 0; i < Dials.Length; i++)
        {
            if (Dials[i].GetDialState() != code[i])
            {
                UpdateCodeText();
                return false;
            }
        }
        displayValues.text = string.Empty;
        return true;
    }

    public override void ScrollInteract(float mouseScrollDelta)
    {
        return;
    }

    private void UpdateCodeText()
    {
        string newCodeText = "";

        for (int i = 0; i < Dials.Length; i++)
        {
            int currentDialValue = Dials[i].GetDialState();
            newCodeText += currentDialValue.ToString();
            displayValues.text = newCodeText;
        }
    }
}
