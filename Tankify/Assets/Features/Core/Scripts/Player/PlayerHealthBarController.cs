using UnityEngine;
using UnityEngine.UI;

namespace Features.Core.Scripts.Player
{
    public class PlayerHealthBarController : MonoBehaviour
    {
        private Slider _healthSlider;
    
        private void Start()
        {
            _healthSlider = GetComponent<Slider>();
        }

        public void SetMaxHealth(int maxHealth)
        {
            _healthSlider.maxValue = maxHealth;
            _healthSlider.value = maxHealth;
        }
        
        public void SetHealth(float health)
        {
            _healthSlider.value = health;
        }
    }
}