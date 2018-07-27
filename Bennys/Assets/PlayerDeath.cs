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
        // Use this for initialization
        void Start()
        {
            hunger = GetComponent<PlayerHunger>();
            hunger.OnDeath += HandleDeath;
            money = GetComponent<PlayerMoney>();
            money.OnDeath += HandleDeath;
            player = PlayerManager.s.player.GetComponent<PlayerController>();
            interact = GetComponent<PlayerInteract>();
            gameover.GetComponent<Canvas>().enabled = false;
      
        }

        void HandleDeath()
        {
            hunger.OnDeath -= HandleDeath;
            money.OnDeath -= HandleDeath;
            Debug.Log("You Died");
            player.enabled = false;
            interact.enabled = false;
            player.render.color = Color.grey;
            StartCoroutine(ReloadScene());
        }
        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3f);
            gameover.GetComponent<Canvas>().enabled = true;

        }
    }
}