using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6Property : MonoBehaviour
{
    [SerializeField]
    public DataPacket data;
}

[System.Serializable]
public class DataPacket
{
    [SerializeField]
    public string name;
    [SerializeField]
    public int health;
    [SerializeField]
    public int mana;
    [SerializeField]
    public int armour;
}