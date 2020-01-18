using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public enum ModifierType{
    Flat = 0,
    AdditivePercentage = 1,
    MultiplicativePercentage  = 2
}

[CreateAssetMenu(fileName="NewStat", menuName="Stat")]
public class BaseStat : ScriptableObject,  ISerializationCallbackReceiver
{
    [SerializeField] private float baseValue = 0f;

    // Might be able to remove NonSerialized, also might be an issue when changing scenes
    [NonSerialized]
    private float runtimeValue = 0f;
    [NonSerialized]
    private float runTimeModifiedValue = 0f;

    private Dictionary<string, Tuple<ModifierType, float>> modifiers = new Dictionary<string, Tuple<ModifierType, float>>();

    private List<string> _keys = new List<string> {};
    private List<Tuple<ModifierType, float>> _values = new List<Tuple<ModifierType, float>> {};


    public void OnBeforeSerialize(){

        _keys.Clear();
        _values.Clear();
        foreach (var kvp in modifiers)
        {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize(){

        modifiers = new Dictionary<string, Tuple<ModifierType, float>>();

        for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
            modifiers.Add(_keys[i], _values[i]);

        runtimeValue = baseValue;
    }

    public void Initialize(){
        runtimeValue = baseValue;
        calculateModifiedValue();
    }
    public void Initialize(float newValue){
        baseValue = newValue;
        runtimeValue = newValue;
        calculateModifiedValue();
    }

    public void AddModifier(string modName, float value, ModifierType type){
        modifiers.Add(modName, Tuple.Create(type, value));
        calculateModifiedValue();
    }

    public void RemoveModifier(string modName){
        modifiers.Remove(modName);
        calculateModifiedValue();
    }

    public void ResetModifiers(){
            modifiers.Clear();
            calculateModifiedValue();
    }


    public void SetValue(float newValue){
        runtimeValue = newValue;
        calculateModifiedValue();
    }

    public void ResetValue(){
        runtimeValue = baseValue;
        calculateModifiedValue();
    }

    public float GetValueUnmodified(){
        return runtimeValue;
    }

    public float GetValue(){
        return runTimeModifiedValue;
    }

    private void calculateModifiedValue(){

        float total = runtimeValue;
        float multiplierAdd = 0f;
        float multiplierMulti = 1f;

        foreach(var tuple in modifiers.Values){
            ModifierType type = tuple.Item1;
            float value = tuple.Item2;

            switch(type){
                case ModifierType.Flat:
                    total += value;
                    break;

                case ModifierType.AdditivePercentage:
                    multiplierAdd += value;
                    break;

                case ModifierType.MultiplicativePercentage:
                    multiplierMulti *= 1 + value/100f;
                    break;
            }
        }

        multiplierAdd = 1 + multiplierAdd/100f;

        total = (total * multiplierAdd * multiplierMulti);
        runTimeModifiedValue = (float)Math.Round(total, 4);
    }

}
