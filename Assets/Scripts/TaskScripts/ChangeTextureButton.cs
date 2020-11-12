using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class ChangeTextureButton : MonoBehaviour
{
    [SerializeField] private CharType _charType = CharType.Male;
    [SerializeField] private MeshType _meshType = MeshType.Body;
    [FormerlySerializedAs("_textureColor")] [SerializeField] [Range(0, 1)] private int _textureNumber = 0;

    private GameObject _character;

    public void Setup(GameObject character)
    {
        _character = character;
    }

    public void SetTexture()
    {
        if (_character == null)
        {
            return;
        }
        
        var path = Path.Combine(Application.streamingAssetsPath, _charType.ToString());
        path = Path.Combine(path, _meshType.ToString());

        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);

        var allFiles = directoryInfo.GetFiles("*.*");

        for(var i = 0; i < allFiles.Length; i++)
        {
            if (i != _textureNumber)
            {
                continue;
            }
            
            var bytes = File.ReadAllBytes(allFiles[i].FullName);
            var texture2D = new Texture2D(1, 1);

            texture2D.LoadImage(bytes);

            var meshes = _character.GetComponents<SkinnedMeshRenderer>();

            SkinnedMeshRenderer smr = meshes[0];
            foreach (var mesh in meshes)
            {
                if(mesh.gameObject.CompareTag(_meshType.ToString()))
                {
                    smr = mesh;
                }
            }

            smr.sharedMaterial.mainTexture = texture2D;
        }
    }
}

public enum CharType
{
    Male,
    Female
}

public enum MeshType
{
    Body,
    Hair
}