using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator
{
    private List<Character> allCharacters;
    private int genID;

    public CharacterGenerator(int charGenID)
    {
        this.genID = charGenID;
        this.allCharacters = new List<Character>();
    }

    public void GenerateCharacters()
    {
        CreateCharacter("Charlemagne", "yolo", "reach0000000000");
        CreateCharacter("Zephyr", "???", "zman70");
        CreateCharacter("Eve", "Buttox", "keeperofFeederof");
    }

    public void CreateCharacter(string nom, string prenom, string user)
    {
        Character newChar = new Character(nom, prenom, user);
        allCharacters.Add(newChar);
    }
}
