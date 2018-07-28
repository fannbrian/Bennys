using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bennys
{
    public class PlayerDeath : MonoBehaviour
    {
        PlayerHunger hunger;
        PlayerMoney money;
        public GameObject gameover;
        PlayerController player;
        PlayerInteract interact;
        Rigidbody velocity;
        Animator animate;
        BoxCollider collider;
        // Use this for initialization

        void Start()
        {
            hunger = GetComponent<PlayerHunger>();
            collider = GetComponent<BoxCollider>();
            hunger.OnDeath += HandleDeath;
            money = GetComponent<PlayerMoney>();
            money.OnDeath += HandleDeath;
            player = PlayerManager.s.player.GetComponent<PlayerController>();
            interact = GetComponent<PlayerInteract>();
            gameover.GetComponent<Canvas>().enabled = false;
            velocity = GetComponent<Rigidbody>();
            animate = GetComponent<PlayerController>().render.GetComponent<Animator>();
       
        }

        void HandleDeath()
        {
            hunger.OnDeath -= HandleDeath;
            money.OnDeath -= HandleDeath;
            velocity.velocity = Vector3.zero;
            animate.enabled = false;
            player.enabled = false;
            interact.enabled = false;
            collider.enabled = false;
            player.render.color = Color.grey;
            player.transform.localRotation = Quaternion.Euler(0, 90, 0);
            StartCoroutine(ReloadScene());
        }
        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2f);
            gameover.GetComponent<Canvas>().enabled = true;

        }
    }
}