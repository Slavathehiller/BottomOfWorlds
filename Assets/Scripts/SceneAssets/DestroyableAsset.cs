using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.SceneAssets.Interfaces
{
    public class DestroyableAsset : MonoBehaviour
    {
        public event UnityAction OnDestroy;

        protected void RaiseDestroyed()
        {
            OnDestroy?.Invoke();
        }
    }
}
