using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{    
    public static Dictionary<int, int> levelToXpNeeded = new Dictionary<int, int>(){
        {1, 50},
        {2, 100},
        {3, 200},
        {4, 400},
    };

    public static Dictionary<int, string> spellHotkeyMap = new Dictionary<int, string>(){
        {1, "Q"},
        {2, "E"},
        {3, "R"},
    };
    public static float gridSize = 0.32f;
}
