using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creation of ScriptableObject thru context menu in Unity project tab 
[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject
{
    public int Value;
}
