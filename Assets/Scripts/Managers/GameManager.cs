using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int sceneIndex = 0;
    private void Awake()
    {
        instance = this;
    }
}
