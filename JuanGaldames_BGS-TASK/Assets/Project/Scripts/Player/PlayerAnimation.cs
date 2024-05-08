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

    public ScriptableItem Cloth { get => cloth; }
    public ScriptableItem Hair { get => hair; }
    public ScriptableItem Hat { get => hat; }

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
        hasCloth = (cloth != null);
        clothRenderer.gameObject.SetActive(hasCloth);
        this.cloth = cloth;
    }

    public void ChangeHair(ScriptableItem hair)
    {
        hasHair = (hair != null);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
        this.hair = hair;
    }

    public void ChangeHat(ScriptableItem hat)
    {
        hasHat = (hat != null);
        hatRenderer.gameObject.SetActive(hasHat);
        hairRenderer.gameObject.SetActive(!hasHat && hasHair);
        this.hat = hat;
    }
}
