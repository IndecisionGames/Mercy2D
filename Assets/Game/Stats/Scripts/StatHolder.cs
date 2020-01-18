using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class StatHolder{

    [SerializeField] private bool UseValue;
    [SerializeField] private float Value;

    public BaseStat StatObject;


    public void Initialize(){
        if(!StatObject){
            UseValue = true;
            StatObject = ScriptableObject.CreateInstance<BaseStat>();
            StatObject.Initialize(Value);
        }
        else if(UseValue){
            StatObject.SetValue(Value);
        }
        else{
            StatObject.Initialize();
            Value = StatObject.GetValue();
        }
    }

    public void AddModifier(string modName, float value, ModifierType type){
        StatObject.AddModifier(modName, value, type);
    }

    public void RemoveModifier(string modName){
        StatObject.RemoveModifier(modName);
    }

    public void ResetModifiers(){
        StatObject.ResetModifiers();
    }

    public void SetValue(float newValue){
        StatObject.SetValue(newValue);
    }

    public void ResetValue(){
        StatObject.ResetValue();
    }

    public float GetValueUnmodified(){
        return StatObject.GetValueUnmodified();
    }

    public float GetValue(){
        return StatObject.GetValue();
    }

}

