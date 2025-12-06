using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainRoutine : MonoBehaviour
{
    [Inject]
    private IGlobalEventBus _eventBus;
    [Inject]
    private ICharacterSocial _character;

    private void Start()
    {
        
    }
}
