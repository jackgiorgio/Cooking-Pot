using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]
public class Item : ScriptableObject {

	public new string name;
    public Sprite icon;

    
    [TextArea]
    public string discoveryText;

    public string customSound;


}