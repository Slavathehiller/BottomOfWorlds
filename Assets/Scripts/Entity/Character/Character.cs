using Assets.Scripts.Entity.Character;
using Assets.Scripts.PlayerStorage;
using System;
using Zenject.SpaceFighter;


public enum PlayerState
{
    Unresolved = -1,
    StandingInTown = 0,
    ReturningFromExploration = 1
}

public class Character : BaseEntity, ICharacterBattle, ICharacterSocial
{
    private MainStats _stats = new();
    private PlayerClassInfo _classInfo = new();
    public PlayerState State { get; set; }
    public PlayerStorage Storage { get; set; } = new();
    public PlayerCart Cart { get; set; } = new();

    public Character()
    {
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
