using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveSO", menuName = "WaveSO")]
public class WaveSO: ScriptableObject
{
    public int creatureAmount = 10;
    public int roundDuration = 30;
    public GameObject creature;
}
