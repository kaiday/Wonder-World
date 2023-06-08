using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text nameText;
    public SpriteRenderer artworkSprite;

    [SerializeField]
    SelectedCharacterScript SelectedCharacter;

    void Start()
    {
        Vector2 beginPos = new Vector2(0, 1);
        this.GetComponent<Transform>().position = beginPos;
        updateCharacter();
    }

    public void NextOption()
    {
        SelectedCharacter.value ++;
        if(SelectedCharacter.value >= characterDB.CharacterCount)
        {
            SelectedCharacter.value = 0;
        }

        updateCharacter();
    }

    public void BackOption()
    {
        SelectedCharacter.value --;
        if (SelectedCharacter.value < 0)
        {
            SelectedCharacter.value = characterDB.CharacterCount - 1;
        }

        updateCharacter();
    }

    private void updateCharacter()
    {
        Character character = characterDB.GetCharacter(SelectedCharacter.value);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }


    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
