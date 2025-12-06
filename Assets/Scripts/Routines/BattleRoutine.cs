using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleRoutine : MonoBehaviour
{
    [Inject]
    private ICharacterBattle _characterBattle;
    [Inject]
    private ICharacterSocial _characterSocial;
    void Start()
    {
        _characterBattle.Name = "Fedor";
        Debug.Log(_characterSocial.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
