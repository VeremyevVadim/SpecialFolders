using UnityEngine;
using UnityEngine.UI;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition = default;
    [SerializeField] private ChangeTextureButton[] _buttons;
    
    private GameObject _character;
    

    public GameObject GetCharacter()
    {
        return _character;
    }
    
    public void LoadCharacter(string character)
    {
        var config = Resources.Load<CharacterInfo>($"Configs/{character}");
        var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");
        
        if (_character != null)
        {
            Destroy(_character);
        }

        _character = Instantiate(prefab, _spawnPosition);

        foreach (var button in _buttons)
        {
            button.Setup(_character);
        }
    }
}
