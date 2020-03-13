using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CharSO",menuName = "new NPC")]
public class CharacterSo : ScriptableObject
{
   public int health;
   public new string name;
   public int strenth;
   public int deff;
   public AudioClip clipDeath;
   public AudioClip clipdamaged;
}
