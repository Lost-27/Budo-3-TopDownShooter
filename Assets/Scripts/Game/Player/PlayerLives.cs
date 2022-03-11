using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class PlayerLives : MonoBehaviour
    {
        [SerializeField] private int _maxLives = 5;
        [SerializeField] private int _currentLives;

        private void Awake()
        {
            _currentLives = _maxLives;
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        //public void RemoveLive()
        //{
        //    CurrentLives--;

        //    if (CurrentLives < 1)
        //        SceneHelper.Instance.LoadScene(3);

        //    OnLivesChanged?.Invoke();
        //}

        //public void AddLive()
        //{
        //    if (CurrentLives >= _maxLives)
        //        return;

        //    CurrentLives++;

        //    OnLivesChanged?.Invoke();
        //}
    }
}
