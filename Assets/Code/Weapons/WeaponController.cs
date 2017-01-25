using UnityEngine;

namespace GameProgramming1
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private float _shootingSpeed;

        private float _shootingRate;
        private float _previouslyShot; // Time elapsed since we shot previvously
        private Weapon[] _weapons;

        // TODO add support for boosters (increase shooting speed etc)

        #region Unity Messages

        protected void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>();
            _shootingRate = 1/_shootingSpeed;
            _previouslyShot = _shootingRate;
        }


        protected void Update()
        {
            _previouslyShot += Time.deltaTime;
        }

        public void Shoot(int projectileLayer)
        {
            // Has enough time elapsed since we ahot previvously

            if (_previouslyShot >= _shootingRate)
            {
                _previouslyShot = 0;

                foreach (Weapon weapon in _weapons)
                {
                    weapon.Shoot(projectileLayer);
                }
            }
        }

        #endregion
    }
}