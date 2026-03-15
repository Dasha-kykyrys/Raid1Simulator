using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Scriptable Objects/StroyNode")]
public class StoryNode : ScriptableObject
{
    public string nodeID;
    public StoryNodeLink[] nextNodes;
    public Client character;          
    public Dialogue dialogue;
}
public class StoryNodeLink
{
    public StoryNode targetNode;
    public NodeCondition[] conditions;
}

public class NodeCondition
{
    public string variable;
    public int requiredValue;
}
