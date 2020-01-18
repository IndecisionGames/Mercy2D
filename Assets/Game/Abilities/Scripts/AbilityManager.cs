using UnityEngine;
using System.Collections;

public class AbilityManager : MonoBehaviour 
{

    [Header("Setup")]
    public GameObject player;
    private GameObject abilityPanel;

    [Header("Abilities")]
    public Ability[] abilities;
    public string[] abilityKeybindings;


    public void Start(){
        
        abilityPanel = gameObject;
        abilityPanel.SetActive(true);

        AbilityController[] abilityControllers = GetComponentsInChildren<AbilityController>();

        for (int i = 0; i < abilityControllers.Length; i++){
            abilityControllers[i].Initialize(abilities[i], player, abilityKeybindings[i]);
        }
    }
}