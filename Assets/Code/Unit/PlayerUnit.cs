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

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer("PlayerProjectile"); }
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