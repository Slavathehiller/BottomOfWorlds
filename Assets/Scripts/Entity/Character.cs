using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Character : BaseEntity, ICharacterBattle, ICharacterSocial
{
    private MainStats _stats;
    private PlayerClassInfo _classInfo;

    public Character(MainStats stats, PlayerClassInfo classInfo)
    {
        _stats = stats;
        _classInfo = classInfo;        
    }
    public int Might
    {
        get
        {
            return _stats.BaseMight + _classInfo.StatsModifier.MightModifier;
        }
    }

    public int Dexterity
    {
        get
        {
            return _stats.BaseDexterity + _classInfo.StatsModifier.DexterityModifier;
        }
    }
    public int Perception
    {
        get
        {
            return _stats.BasePerception + _classInfo.StatsModifier.PerceptionModifier;
        }
    }
    public int Will
    {
        get
        {
            return _stats.BaseWill + _classInfo.StatsModifier.WillModifier;
        }
    }

    public override int MaxHitPoints => Might * 10; 

    public void ChangeClass(Type newClass)
    {
        if (!newClass.IsSubclassOf(_classInfo.GetType()))
            throw new SystemException("Invalid character class");
        _classInfo = Activator.CreateInstance(newClass) as PlayerClassInfo;
    }
}
