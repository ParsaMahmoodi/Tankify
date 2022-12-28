using UnityEngine;

namespace Features.Core.Scripts
{
    public class LookAtObject : MonoBehaviour
    {
        private GameObject _gameObject;
        
        // Start is called before the first frame update
        void Start()
        {
            _gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _gameObject.transform.position);
        }
    }
}
