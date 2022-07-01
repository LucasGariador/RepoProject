using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Conversation", menuName = "Dialogue")]
public class DialoguesScriptable : ScriptableObject
{
    public Speakers[] speakers;
    [TextArea]
    public string[] dialogue;
}
