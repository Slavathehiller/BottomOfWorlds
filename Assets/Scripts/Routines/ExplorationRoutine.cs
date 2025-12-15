using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using Assets.Scripts.SceneAssets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = Assets.Scripts.Interfaces.ILogger;

namespace Assets.Scripts.Routines
{
    public abstract class ExplorationRoutine : MonoBehaviour
    {
        [SerializeField]
        private int _numberOfResourcePoints = 20;
        [SerializeField]
        private float _minX = -7f; 
        [SerializeField]
        private float _maxX = 7f;
        [SerializeField]
        private float _minY = -2f;
        [SerializeField]
        private float _maxY = 3f;

        [Inject]
        protected ISceneAssetFactory _assetFactory;
        [Inject]
        protected ILogger _logger;
        [Inject]
        protected ICharacter _character;

        [SerializeField]
        protected ExplorationResourceDisplay _resourcesDisplay;

        [Inject]
        protected IExplorationEventBus _eventBus;

        private void Awake()
        {
            Init();
            _eventBus.SubscribeToHarvestResource(this, ShowResourceHarvest);
        }

        private void Start()
        {
            _resourcesDisplay.DisplayResource(_character.Cart.Resources);
        }

        protected abstract void Init();

        protected void ShowResourceHarvest(PlayerResources resources)
        {
            _character.Cart.Resources = _character.Cart.Resources + resources;
            _resourcesDisplay.DisplayResource(_character.Cart.Resources);
        }

        public void ToTownButtonClick()
        {
            _character.State = PlayerState.ReturningFromExploration;
            SceneManager.LoadScene(Scenes.MAIN_SCENE);
        }

        protected void SpawnResourcesPoints<T>() where T : ResourcePoint
        {
            for (var i = 1; i <= _numberOfResourcePoints; i++)
            {
                var resPoint = _assetFactory.CreateAsset<T>();
                var x = Random.Range(_minX, _maxX + 1);
                var y = Random.Range(_minY, _maxY + 1);
                resPoint.transform.position = new Vector3(x, y, 0);
                resPoint.Harvest += _eventBus.OnHarvestResource;
            }
        }

        protected void OnDestroy()
        {
            _eventBus.UnsubscribeAll();
        }

    }
}
