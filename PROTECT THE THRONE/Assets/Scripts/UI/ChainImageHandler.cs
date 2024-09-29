using System.Collections.Generic;
using UnityEngine;

public class ChainImageHandler : MonoBehaviour
{

    // Sprites
    private Dictionary<ChainSprite, Sprite> chainSpriteMap;

    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite availableSprite;
    [SerializeField] private Sprite occupiedSprite;


    //----------------------------------------------------------------------------------------------------------------------------//


    // Start
    private void Awake()
    {
        InitializeSpriteMap();
    }



    //----------------------------------------------------------------------------------------------------------------------------//


    // Sprite Mapping
    private void InitializeSpriteMap()
    {
        chainSpriteMap = new Dictionary<ChainSprite, Sprite>
        {
            {ChainSprite.Locked, lockedSprite},
            {ChainSprite.Available, availableSprite},
            {ChainSprite.Occupied, occupiedSprite},
        };
    }


    // Returns the sprite based on the enum value that is passed in
    // It will then return said value so that update sprite knows the corresponding sprite
    private Sprite GetSpriteMap(ChainSprite sprite)
    {
        return chainSpriteMap.ContainsKey(sprite) ? chainSpriteMap[sprite] : null;
    }


    // Update current chain sprite with new chain sprite (Unlocked/Available/Occupied)
    // It uses the above function to fetch the corresponding sprite
    public void UpdateCurrentSprite(Chain chain, ChainSprite newSprite)
    {
        // Returns corresponding sprite
        Sprite fetchedMapSprite = GetSpriteMap(newSprite);


        // Will then set the sprite of the passed in chain
        if (fetchedMapSprite != null)
        {
            switch (newSprite)
            {
                case ChainSprite.Available:
                    chain.chainImage.color = Color.blue;
                    break;
                case ChainSprite.Occupied:
                    chain.chainImage.color = Color.black;
                    break;
                case ChainSprite.Locked:
                    chain.chainImage.color = Color.red;
                    break;
            }
            chain.chainImage.sprite = fetchedMapSprite;
        }
    }


    // Update Chain Sprite with demon sprite
    // Heavy WIP
    public void UpdateSpriteWithDemon(Chain chain)
    {
        chain.chainImage.sprite = chain.assignedDemon.sprite;
    }


}