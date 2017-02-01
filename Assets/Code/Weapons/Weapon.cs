using GameProgramming1.Utility;
using UnityEngine;
using GameProgramming1.Systems;
using ProjectileType = GameProgramming1.Projectile.ProjectileType;

namespace GameProgramming1
{
    public class Weapon : MonoBehaviour, IShooter
    {
        [SerializeField] private ProjectileType _projectileType;

        public void Shoot(int projectileLayer)
        {
            Projectile projectile = GetProjectile();

            if (projectile != null)
            {
                projectile.gameObject.SetActive(true);
                projectile.transform.position = transform.position;
                projectile.transform.forward = transform.forward;
                projectile.gameObject.SetLayer(projectileLayer);
                projectile.Shoot(this,transform.forward);
            }

            else
            {
                Debug.LogError("Could not get projectile!");
            }
        }

        private Projectile GetProjectile()
        {
            Projectile result = null;

            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);


            if (pool != null)
            {
                result = pool.GetPooledObject();
            }



            return result;
        }

        /// <summary>
        /// Projectile hit something. Lets return it to pool.
        /// </summary>
        /// <param name="projectile">The collided projectile</param>
        public void ProjectileHit(Projectile projectile)
        {
            ProjectilePool pool = Global.Instance.Pools.GetPool(_projectileType);

            if (pool != null)
            {
                pool.ReturnObjectToPool(projectile);
            }
            else
            {
                Destroy(projectile.gameObject);
            }

        }
    }
}