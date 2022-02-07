using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYO_ShopManager : MonoBehaviour
{
    List<Sprite> sprites = new List<Sprite>();

    public Sprite[] skins;

    public Sprite spriteSelected;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Sprite s in skins)
        {
            sprites.Add(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSelectedSprite(int skin)
    {
        spriteSelected = sprites[skin];
    }
}
