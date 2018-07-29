using UnityEngine;

namespace Bennys
{
    /// <summary>
    /// Includes reference and flags for player. Pretty messy code but it works.
    /// 
    /// Brian Fann
    /// 7/21/18
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager s { get; set; }
        public GameObject player;
        public float GracePeriod;
        public int MoneyLostWhenServed;
        public int HungerAddedWhenServed;

        public bool IsGrabbed
        {
            get
            {
                return _isGrabbed;
            }
            set
            {
                player.layer = value ? 10 : 9;
                _isGrabbed = value;
            }
        }
        public bool IsSeated
        {
            get
            {
                return _isSeated;
            }
            set
            {
                player.layer = value ? 10 : 9;
                _isSeated = value;
            }
        }
        bool _isSeated;
        bool _isGrabbed;

        void Awake()
        {
            s = this;
        }

        public void ReleasePlayer()
        {
            Invoke("OnRelease", GracePeriod);
        }

        private void OnRelease()
        {
            IsGrabbed = false;
            IsSeated = false;
        }
    }
}