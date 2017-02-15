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
            Data = playerData;
        }

        protected override void Die()
        {
            // TODO: Handle dying properly
            // Instantiate explosion effects
            // Play sound
            // Decrease lives
            // Respawn player
            gameObject.SetActive(false);

            base.Die();
        }

        public void UpdateUnit(float horizontalInput, float verticalInput, bool shoot)
        {
            Mover.MoveToDirection(new Vector3(horizontalInput, 0, verticalInput));

            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }
        }
    }
}