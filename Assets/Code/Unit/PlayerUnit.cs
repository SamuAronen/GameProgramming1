using GameProgramming1.Configs;
using GameProgramming1.Data;
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

        public UnitType Type { get { return _type; } }
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
            gameObject.SetActive(false);
        }

        protected void Update()
        {


            Mover.MoveToDirection(new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")));


            bool shoot = Input.GetButton("Shoot");

            if (shoot)
            {
                Weapons.Shoot(ProjectileLayer);
            }

        }
    }
}