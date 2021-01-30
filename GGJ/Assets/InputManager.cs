using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability
{
    Left,
    Jump,
    Right,
    COUNT
}

public class InputManager : MonoBehaviour
{
    bool[] mActiveAbilities;
    bool[] mAvailableAbilities;
    Ability mLastAbilityUsed;

    public float horizontal { get { return (GetAbility(Ability.Left) ? -1f : 0f) + (GetAbility(Ability.Right) ? 1f : 0f); } }
    public bool jump { get { return GetAbility(Ability.Jump); } }

    void Start()
    {
        int numAbilities    = (int) Ability.COUNT;
        mActiveAbilities    = new bool[numAbilities];
        mAvailableAbilities = new bool[numAbilities];
        for (int i = 0; i < numAbilities; i++) mAvailableAbilities[i] = true;
    }

    void Update()
    {
        // Get inputs
        SetActiveAbility(Ability.Jump, Input.GetButtonDown("Jump"));
        SetActiveAbility(Ability.Left, Input.GetButton("Left"));
        SetActiveAbility(Ability.Right, Input.GetButton("Right"));
    }

    bool GetAbility(Ability ability)
    {
        int index = (int) ability;
        return mActiveAbilities[index] && mAvailableAbilities[index];
    }

    void SetActiveAbility(Ability ability, bool active)
    {
        int index = (int) ability;
        mActiveAbilities[index] = active;
        if (active)
        {
            mLastAbilityUsed = ability;
        }
    }

    public Ability ConsumeLastAbility()
    {
        mAvailableAbilities[(int)mLastAbilityUsed] = false;
        return mLastAbilityUsed;
    }

    public void EnableAbility(Ability ability)
    {
        mAvailableAbilities[(int)ability] = true;
    }
}
