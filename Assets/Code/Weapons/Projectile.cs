using UnityEngine;

namespace GameProgramming1
{
    public class Projectile : MonoBehaviour
    {
        public enum ProjectileType
        {
            None = 0,
            Laser = 1,
            Explosive = 2,
            Missile = 3
        }

        #region Unity Fields

        [SerializeField] private float _shootingForce;
        [SerializeField] private int _damage;
        [SerializeField] private ProjectileType _projectileType;

        #endregion

        private IShooter _shooter;
        public Rigidbody RigidBody { get; private set; }

        public ProjectileType Type { get { return _projectileType; } }


        #region Unity Messages

        


        protected virtual void Awake()
        {
            RigidBody = GetComponent<Rigidbody>();
        }

       

        protected void OnCollisionEnter(Collision collision)
        {
            // Collision, Projectile hit something
            IHealth damageReceiver = collision.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                // Colliding object can take damage
                damageReceiver.TakeDamage(_damage);

                // TODO Instantiate effect
                // TODO Add sound effect

                _shooter.ProjectileHit(this);
            }

        }
        #endregion

        public void Shoot(IShooter shooter, Vector3 direction)
        {
            _shooter = shooter;
            RigidBody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                _shooter.ProjectileHit(this);

            }
        }
    }
}