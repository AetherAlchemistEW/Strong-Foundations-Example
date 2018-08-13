using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6FakeNonEditorEditor : MonoBehaviour
{
    [Header("Player Variables")]
    [Space] [Range(10,100)]
    public int maxHealth;

    [HideInInspector]
    public int curHealth;

    [Space]
    public string charName;
    [TextArea][Tooltip("The player's biography")]
    public string bio;
}
