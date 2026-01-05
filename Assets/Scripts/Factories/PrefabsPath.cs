using Assets.Scripts.SceneAssets.Mountains;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public static class PrefabsPath
    {

        private static Dictionary<Type, string> _pathes = new();

        public static void Register(Type type, string path)
        {
            if (_pathes.ContainsKey(type))
            {
                Debug.LogError($"Type {type.FullName} already registered in PrefabPath.");
                return;
            }

            _pathes.Add(type, path);
        }

        public static string GetPathFor<T>()
        {
            string result;
            if (!_pathes.TryGetValue(typeof(T), out result))
            {
                Debug.LogError($"Type {typeof(T).FullName} not registered in PrefabPath.");
            }
            return result;
        }


        public static void InitPathes()
        {
            Register(typeof(TreesGroup), "SceneAssets/Forest/TreesGroup");
            Register(typeof(RockFormation), "SceneAssets/Mountains/RockFormation");
            Register(typeof(RockFormationWithIronOre), "SceneAssets/Mountains/RockFormationWithIronOre");
            Register(typeof(RockFormationWithCoal), "SceneAssets/Mountains/RockFormationWithCoal");            
            Register(typeof(PopupText), "SceneAssets/PopupText");
            Register(typeof(SettingsWindow), "SceneAssets/UI/SettinglWindow");
            Register(typeof(UITooltip), "SceneAssets/UI/UITooltip");
            Register(typeof(SceneTooltip), "SceneAssets/SceneTooltip");           
            Register(typeof(ResourcesDisplayController), "SceneAssets/UI/ResourcesDisplayController");

            
        }

    }
}
