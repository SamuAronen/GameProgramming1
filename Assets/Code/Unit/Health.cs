using GameProgramming1;
using UnityEngine;

namespace GameProgramming1
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] private int _health;

        private bool _isInvulnerable = false;
        private MeshRenderer _renderer;

        private int _originalHealth;
        private float _invulnerableTimer = 0;

        private float _blinkTime = 0.08f;
        private float _blinkTimer = 0.08f;

        private void Awake()
        {
            _originalHealth = _health;
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if (_isInvulnerable && _invulnerableTimer > 0)
            {
                _invulnerableTimer -= Time.deltaTime;

                _blinkTimer -= Time.deltaTime;

                if (_blinkTimer < 0)
                {
                    _blinkTimer = _blinkTime;
                    _renderer.enabled = !_renderer.enabled;
                }

                if (_invulnerableTimer <= 0)
                {
                    _isInvulnerable = false;
                    _renderer.enabled = true;
                }
            }
        }

        public int CurrentHealth
        {
            get { return _health; }
            set
            {
                _health = Mathf.Clamp(value, 0, value);
                if (HealthChanged != null)
                {
                    HealthChanged(this, new HealthChangedEventArgs(_health));
                }
            }
        }

        public void ResetHealth()
        {
            Debug.Log("Reset");
            _health = _originalHealth;
        }

        public void SetInvulnerable(float timeSeconds)
        {
            _isInvulnerable = true;
            _blinkTimer = _blinkTime;
            _invulnerableTimer = timeSeconds;
        }

        /// <summary>
        /// Reduces health when this method is called.
        /// </summary>
        /// <param name="damage">Amount of health reduced</param>
        /// <returns>True, if helth reaches 0, false otherwise</returns>
        public bool TakeDamage(int damage)
        {
            if (!_isInvulnerable)
            {
                CurrentHealth -= damage;
            }

            return CurrentHealth == 0;
        }

        public event HealthChangedDelegate HealthChanged;
    }
}