using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "Scriptable Objects/StroyNode")]
public class StoryNode : ScriptableObject
{
    public string nodeID;
    public StoryNode[] nextNodes;
    public string[] triggersID;
    public Client character;          
    public Dialogue dialogue;
    public float duration;
}
