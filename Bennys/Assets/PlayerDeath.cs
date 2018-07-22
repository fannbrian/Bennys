using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bennys
{
    public class PlayerDeath : MonoBehaviour
    {
        PlayerHunger hunger;
        PlayerMoney money;
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
        }

        void HandleDeath()
        {
            hunger.OnDeath -= HandleDeath;
            money.OnDeath -= HandleDeath;
            Debug.Log("You Died");
            player.enabled = false;
            interact.enabled = false;
            StartCoroutine(ReloadScene());
        }
        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Main Menu");
        }
    }
}