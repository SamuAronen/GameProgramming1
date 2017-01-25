using System;

namespace GameProgramming1
{
    public class HealthChangedEventArgs : EventArgs
    {
        public int CurrentHealth { get; private set; }

        public HealthChangedEventArgs(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }
    }

    public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

    public interface IHealth
    {
        int CurrentHealth { get; set; }

        /// <summary>
        /// Reduces health when this method is called.
        /// </summary>
        /// <param name="damage">Amount of health reduced</param>
        /// <returns>True, if helth reaches 0, false otherwise</returns>
        bool TakeDamage(int damage);

        /// <summary>
        /// This event is fired every time the health changes
        /// </summary>
        event HealthChangedDelegate HealthChanged;


        

    }
}