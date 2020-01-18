using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject {

    public string Name = "New Ability";
    public Sprite Sprite;
    public AudioClip Sound;
    public float BaseCooldown = 1f;
    public float ActiveTime = 0f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
    public abstract void OnAbilityEnd();
}