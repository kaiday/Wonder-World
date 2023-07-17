using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SelectedCharacterScript : ScriptableObject
{
    [SerializeField]
    public int _value;

    public int value
    {
        get { return _value; }
        set { _value = value; }
    }
}
