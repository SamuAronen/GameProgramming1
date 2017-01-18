using GameProgramming1;
using UnityEngine;


namespace GameProgramming1
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private int _health;

        public int CurrentHealth
        {
            get { return _health; }
            set
            {
                _health = Mathf.Clamp(value,0,value);
                if (HealthChanged != null)
                {
                    HealthChanged(this,new HealthChangedEventArgs(_health));
                }
            }
        }

        /// <summary>
        /// Reduces health when this method is called.
        /// </summary>
        /// <param name="damage">Amount of health reduced</param>
        /// <returns>True, if helth reaches 0, false otherwise</returns>
        public bool TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            return CurrentHealth == 0;
        }

        public event HealthChangedDelegate HealthChanged;
    }
}