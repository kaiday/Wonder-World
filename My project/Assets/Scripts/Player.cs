using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;

    [SerializeField]
    public SelectedCharacterScript SelectedCharacter;

    public RuntimeAnimatorController frog;
    public RuntimeAnimatorController spaceMan;
    public RuntimeAnimatorController pinkMan;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       

        Debug.Log(SelectedCharacter.value);
        Character character = characterDB.GetCharacter(SelectedCharacter.value);
        artworkSprite.sprite = character.characterSprite;
        anim = this.GetComponent<Animator>();

        if (SelectedCharacter.value == 0)
        {
            anim.runtimeAnimatorController = frog;
        }
        else if (SelectedCharacter.value == 1)
        {
            anim.runtimeAnimatorController = pinkMan;
        }
        else if (SelectedCharacter.value == 2)
        {
            anim.runtimeAnimatorController = spaceMan;
        }
    }
   


}