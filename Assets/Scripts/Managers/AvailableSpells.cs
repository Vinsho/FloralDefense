using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableSpells : MonoBehaviour
{
    [SerializeField] Spell wrath;
    [SerializeField] Spell mudPool;

    private Dictionary<Spells, Spell> availableSpells = new Dictionary<Spells, Spell>();
    public Dictionary<int, Spells> activeSpells = new Dictionary<int, Spells>();

    void Start() {
        availableSpells[Spells.wrath] = wrath;    
        availableSpells[Spells.mudPool] = mudPool;    

        // TODO this should be set from memory, when active flower selecting is enabled.
        activeSpells[1] = Spells.wrath;
        activeSpells[2] = Spells.mudPool;
    }

    public Spell GetSpell(Spells spell){
        return availableSpells[spell];
    }

    public Spell GetActiveSpellAtIndex(int idx){
        return GetSpell(activeSpells[idx]);
    }
}
