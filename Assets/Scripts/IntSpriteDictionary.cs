using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntSpriteDictionary", menuName = "Scriptables/IntSpriteDictionary")]
public class IntSpriteDictionary : ScriptableObject
{
    public Sprite[] numbers = new Sprite[10]; 
}