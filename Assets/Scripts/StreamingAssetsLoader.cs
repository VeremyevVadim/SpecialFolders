using System;
using System.IO;
using TMPro;
using UnityEngine;


public class StreamingAssetsLoader : MonoBehaviour
{
    [SerializeField] private ImageData _baseIcon;

    private void Start()
    {
        _baseIcon.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        
        var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        Debug.Log($"Streaming path: {Application.streamingAssetsPath}");

        var allFiles = directoryInfo.GetFiles("*.*");

        foreach (var file in allFiles)
        {
            Debug.Log($"File name {file.Name}");

            if (file.Name.Contains("meta"))
            {
                continue;
            }

            var imageData = Instantiate(_baseIcon, _baseIcon.transform.parent);
            imageData.gameObject.SetActive(true);
            var bytes = File.ReadAllBytes(file.FullName);
            var texture2D = new Texture2D(1, 1);

            texture2D.LoadImage(bytes);
            
            var rect = new Rect(0, 0, texture2D.width, texture2D.height);
            var pivot = Vector2.one * 0.5f;

            var sprite = Sprite.Create(texture2D, rect, pivot);
            imageData.Image.sprite = sprite;
            imageData.Text.text = file.Name;
        }
        
        _baseIcon.gameObject.SetActive(false);
    }
}
