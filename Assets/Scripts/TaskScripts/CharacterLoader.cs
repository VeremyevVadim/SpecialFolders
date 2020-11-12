using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition = default;
    
    private GameObject _character;
    
    public void LoadCharacter(string character)
    {
        var config = Resources.Load<CharacterInfo>($"Configs/{character}");
        var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");
        
        if (_character != null)
        {
            Destroy(_character);
        }

        _character = Instantiate(prefab, _spawnPosition);
    }
}
