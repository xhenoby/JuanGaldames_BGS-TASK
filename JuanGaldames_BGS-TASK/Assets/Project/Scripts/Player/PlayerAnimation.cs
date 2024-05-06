using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int bodieNumber;
    [SerializeField] int clothesNumber;
    [SerializeField] int hairsNumber;
    [SerializeField] int hatsNumber;
    [SerializeField] bool hasHair;
    [SerializeField] bool hasHat;

    [Header("References")]
    [SerializeField] SpriteRenderer bodyRenderer;
    [SerializeField] SpriteRenderer clothRenderer;
    [SerializeField] SpriteRenderer hairRenderer;
    [SerializeField] SpriteRenderer hatRenderer;

    [Header("Assets")]
    [SerializeField] SpriteItems[] bodies;
    [SerializeField] SpriteItems[] clothes;
    [SerializeField] SpriteItems[] hairs;
    [SerializeField] SpriteItems[] hats;
    private void Start()
    {
        hatRenderer.gameObject.SetActive(hasHat);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
    }
    private void Update()
    {
        hatRenderer.gameObject.SetActive(hasHat);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
    }
    void LateUpdate()
    {
        ChangeSprite(bodieNumber, bodyRenderer, bodies);
        ChangeSprite(clothesNumber, clothRenderer, clothes);
        ChangeSprite(hatsNumber, hatRenderer, hats);
        ChangeSprite(hairsNumber, hairRenderer, hairs);
    }

    void ChangeSprite(int itemNumber, SpriteRenderer renderer, SpriteItems[] spriteItems)
    {
        string spriteName = renderer.sprite.name;
        string textureName = renderer.sprite.texture.name;

        spriteName = spriteName.Replace(textureName, "");
        spriteName = spriteName.Replace("_", "");

        int spriteNumber = int.Parse(spriteName);

        itemNumber = Mathf.Clamp(itemNumber, 0, spriteItems.Length - 1);

        renderer.sprite = spriteItems[itemNumber].sprites[spriteNumber];
    }
}

[Serializable]
struct SpriteItems
{
    public string name;
    public Sprite[] sprites;
}
