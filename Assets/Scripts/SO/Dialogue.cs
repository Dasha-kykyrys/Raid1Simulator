using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueNode startNode;
}

public class DialogueNode
{
    public string text;
    public DialogueChoice[] choices;
}

public class DialogueChoice
{
    public string choiceText;
    public int effectindex;
    public DialogueNode nextNode;
}
