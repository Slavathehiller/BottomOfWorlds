using Assets.Scripts.PlayerStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICharacterSocial : ICharacter
{
    public PlayerStorage Storage { get; set; }
}

