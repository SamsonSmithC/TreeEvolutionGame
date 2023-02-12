// Original Author - Sam Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FactoryLuna.Core.Singletons;

namespace TreeEvolutionGame {
  public class TreeManager : SingletonMonoBehavior<TreeManager>
  {
    // How many point the player has to spend on mutations.
    public int RootStrength {get; private set;} = 0;
    // How much RootStrength the player regens each round.
    public int RootRegen {get; private set;} = 1;

    // The game is lost when this hits zero... probably.
    public int Health {get; private set;} = 100;
    // How much health the player regens each round.
    public int HealthRegen {get; private set;} = 1;

    // A threshold damage must reach before reducing health.
    public int Defense {get; private set;} = 0;

    // The stage of growth to display the tree at.
    public int GrowthStage {get; private set;} = 0;

    
    [SerializeField]
    private GameObject HealthBarFill = null;
    private float HealthFullScale = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        HealthFullScale = HealthBarFill.transform.localScale.y;
    }

    public void Damage(int damage)
    {
        if (damage > Defense) {Health -= (damage-Defense);}
    }

    public void ReduceDef(int red)
    {
        Defense -= red;
        if (Defense < 0) {Defense = 0;}
    }

    public void PierceDamage(int dmg)
    {
        Health -= dmg;
    }

    public void RegenUp(int regUp)
    {
        HealthRegen += regUp;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        HealthBarFill.transform.localScale = new Vector3 (4, HealthFullScale*(Health/100f), 1);
    }


    private void DoTreeTick()
    {
        if (Health <= 0)
        {
            // Game Over.
            Debug.LogError("The game should be ended right now...");
        }

        Health += HealthRegen;
        if (Health > 100) { Health = 100; }

        RootStrength += RootRegen;
    }
  }
}