using Assets.Scripts.Routines;
using Assets.Scripts.SceneAssets.Mountains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;


public class MountainRoutine : ExplorationRoutine
{
    protected override void Init()
    {
        SpawnResourcesPoints<RockFormation>();
    }

    public void ToMineButtonClick()
    {
        SceneManager.LoadScene(Scenes.MINE_SCENE);
    }
}

