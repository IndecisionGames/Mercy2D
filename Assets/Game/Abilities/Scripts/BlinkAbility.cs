using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Abilities/BlinkAbility")]
public class BlinkAbility : Ability {

    public float blinkDistance = 7.0f;

    private Transform objTransform;

    public override void Initialize(GameObject obj){
        objTransform = obj.GetComponent<Transform>();
    }

    public override void TriggerAbility(){

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 blinkVector = (mousePosition - objTransform.position).normalized;
        
        objTransform.position += blinkVector*blinkDistance;
    }

    public override void OnAbilityEnd(){}

}