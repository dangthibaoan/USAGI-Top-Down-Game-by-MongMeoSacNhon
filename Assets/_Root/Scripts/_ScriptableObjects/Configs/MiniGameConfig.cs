using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameConfig", menuName = "Game/MiniGameConfig")]
public class MiniGameConfig : ScriptableObject
{
    public List<MiniGame> ListMiniGames;
}