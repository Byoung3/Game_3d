using UnityEngine;
using UnityEngine.Rendering;

public class SpriteToTexture : MonoBehaviour
{
    public Material targetMaterial; 
    public Sprite sourceSprite;

    public Texture2D ConvertSpriteToTexture()
    {
        if (sourceSprite == null)
        {
            Debug.LogError("Source Sprite is not assigned!");
            return null;
        }

        // Create a new Texture2D with the dimensions of the sprite's rectangle
        Texture2D myTexture = new Texture2D((int)sourceSprite.rect.width, (int)sourceSprite.rect.height);

        // Get the pixels from the original texture corresponding to the sprite's rectangle
        Color[] pixels = sourceSprite.texture.GetPixels(
            (int)sourceSprite.textureRect.x,
            (int)sourceSprite.textureRect.y,
            (int)sourceSprite.textureRect.width,
            (int)sourceSprite.textureRect.height
        );

        // Set the pixels to the new Texture2D
        myTexture.SetPixels(pixels);

        // Apply the changes to the new texture
        myTexture.Apply();


        return myTexture;
    }

    // Example usage:
    void Start()
    {
        Texture2D newTexture = ConvertSpriteToTexture();
        if (newTexture != null)
        {
            targetMaterial.SetTexture("_MainTex", newTexture);
            Debug.Log("Sprite converted to Texture2D successfully!");
        }
    }
}
