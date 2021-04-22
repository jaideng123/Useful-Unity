using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DisplayVariableAsText : MonoBehaviour
{
    public ScriptableObject value;
    private TextMeshProUGUI textDisplay;

    void Start()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textDisplay.text = value.ToString();
    }

}
