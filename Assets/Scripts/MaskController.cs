using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Sprite WaveSprite;
    public RenderTexture WaveSpriteTexture;
    public SpriteRenderer sprRend;

    public SpriteMask mask;

    // Start is called before the first frame update
    void Start()
    {
        //WaveSprite = Sprite.Create(WaveSpriteTexture, new Rect(0, 0, 512, 512), Vector2.one / 2);
        sprRend.sprite = WaveSprite;
        mask.sprite = WaveSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D t2d = new Texture2D(WaveSpriteTexture.width, WaveSpriteTexture.height,TextureFormat.RGBA32,false);
        RenderTexture.active = WaveSpriteTexture;

        t2d.ReadPixels(new Rect(0, 0, WaveSpriteTexture.width, WaveSpriteTexture.height), 0, 0);
        t2d.Apply();

        WaveSprite = Sprite.Create(t2d, new Rect(0, 0, WaveSpriteTexture.width, WaveSpriteTexture.height), Vector2.up);

        sprRend.sprite = WaveSprite;
        mask.sprite = WaveSprite;
    }
}
