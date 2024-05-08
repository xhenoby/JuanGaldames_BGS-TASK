using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SpriteRenderer clothRenderer;
    [SerializeField] SpriteRenderer hairRenderer;
    [SerializeField] SpriteRenderer hatRenderer;

    ScriptableItem cloth;
    ScriptableItem hair;
    ScriptableItem hat;

    bool hasCloth;
    bool hasHair;
    bool hasHat;

    private void Start()
    {
        clothRenderer.gameObject.SetActive(hasCloth);
        hatRenderer.gameObject.SetActive(hasHat);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
    }

    void LateUpdate()
    {
        if (hasCloth) ChangeSprite(clothRenderer, cloth.sprites);
        if (hasHat) ChangeSprite(hatRenderer, hat.sprites);
        if (!hasHat && hasHair) ChangeSprite(hairRenderer, hair.sprites);
    }

    void ChangeSprite(SpriteRenderer renderer, Sprite[] sprites)
    {
        string spriteName = renderer.sprite.name;
        string textureName = renderer.sprite.texture.name;

        spriteName = spriteName.Replace(textureName, "");
        spriteName = spriteName.Replace("_", "");

        int spriteNumber = int.Parse(spriteName);

        renderer.sprite = sprites[spriteNumber];
    }

    public void ChangeCloth(ScriptableItem cloth)
    {
        if (cloth == null)
        {
            hasCloth = false;
            clothRenderer.gameObject.SetActive(hasCloth);
            return;
        }

        hasCloth = true;
        clothRenderer.gameObject.SetActive(hasCloth);
        this.cloth = cloth;
    }

    public void ChangeHair(ScriptableItem hair)
    {
        if (hair == null)
        {
            hasHair = false;
            hairRenderer.gameObject.SetActive(!hasHat && hasHair);
            return;
        }

        hasHair = true;
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
        this.hair = hair;
    }
    public void ChangeHat(ScriptableItem hat)
    {
        if (hat == null)
        {
            hasHat = false;
            hatRenderer.gameObject.SetActive(hasHat);
            hairRenderer.gameObject.SetActive(!hasHat && hasHair);
            return;
        }

        hasHat = true;
        hatRenderer.gameObject.SetActive(hasHat);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
        this.hat = hat;
    }
}
