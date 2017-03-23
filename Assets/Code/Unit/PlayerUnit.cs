using GameProgramming1.Configs;
using GameProgramming1.Data;
using GameProgramming1.InputChecks;
using UnityEngine;

namespace GameProgramming1
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 2,
            Heavy = 3
        }

        [SerializeField] private UnitType _type;
        [SerializeField] private float _invulnerabilityTime = 1;

        private PlayerSpawner _spawner;
        public UnitType Type
        {
            get { return _type; }
        }

        public PlayerData Data { get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayerName); }
        }

        public void Init(PlayerData playerData)
        {
            _spawner = FindObjectOfType<PlayerSpawner>();
            InitRequiredComponents();
            Data = playerData;
            Health.SetInvulnerable(_invulnerabilityTime);
        }

        protected override void Die()
        {
            // TODO: Handle dying properly
            // Instantiate explosion effects
            // Play sound
            // Decrease lives
            // Respawn player

            if (Data.Lives > 1)
            {

                Data.Lives--;
                Health.ResetHealth();
                Debug.Log("Lives Remaining:" + Data.Lives);
                _spawner.ReSpawnPlayer(this);
                Health.SetInvulnerable(_invulnerabilityTime);
            }
            else
            {
                Debug.Log(Data.Id + "Is Fully Dead");
                gameObject.SetActive(false);

                // Base Removes health changed event
                base.Die();

            }
        }

        // These methods are added instead of calling Mover and Weapons directly in case if some player unit specific behaviour is needed in the future

        /// <summary>
        /// Updates the unit movement with information from input manager
        /// </summary>
        /// <param name="horizontalInput">horizontal movement</param>
        /// <param name="verticalInput">vertical movement</param>
        public void Move(float horizontalInput, float verticalInput)
        {
            Mover.MoveToDirection(new Vector3(horizontalInput, 0, verticalInput));
        }

        /// <summary>
        /// Updates the unit shooting with information from input manager
        /// </summary>
        /// <param name="shoot">Shoot with the unit</param>
        public void Shoot(bool shoot)
        {
            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
        }
    }
}