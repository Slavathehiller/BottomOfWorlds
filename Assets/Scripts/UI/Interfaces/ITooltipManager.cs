using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Interfaces
{
    public interface ITooltipManager
    {
        public void ShowUITooltip(string text, Vector2 screenPosition, GameObject parent);
        public void ShowSceneTooltip(string text, Vector2 screenPosition);
        public void Hide();
    }
}
