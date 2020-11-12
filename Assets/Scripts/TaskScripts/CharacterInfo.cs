using UnityEngine;

[CreateAssetMenu]
public class CharacterInfo : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private string prefabName;

    public string CharacterName => characterName;
    public string PrefabName => prefabName;
}
