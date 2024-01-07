using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Config_PlayerData", menuName = "Game/Config_PlayerData")]
public class Config_PlayerData : ScriptableObject
{
    public Vector3 PlayerPositionCurrent;
    public bool isMoving = false;
    public bool isActiveMovement = true;
    public int status;
    [TextArea(2, 10)] public string statusDescription = "0 - Down, 1 - Left, 2 - Right, 3 - Up";
}