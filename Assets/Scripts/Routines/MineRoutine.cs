using Assets.Scripts.Routines;
using Assets.Scripts.SceneAssets.Mountains;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRoutine : ExplorationRoutine
{
    protected override void Init()
    {
        SpawnResourcesPoints<RockFormationWithIronOre>();
        SpawnResourcesPoints<RockFormationWithCoal>();
    }
}
