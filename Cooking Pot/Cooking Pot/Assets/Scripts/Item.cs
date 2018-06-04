using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]
public class Item : ScriptableObject {

	public new string name;
    public Sprite icon;
    public bool isCookable;
    public bool isStackable;
    public bool isEatable;
    
    [TextArea]
    public string discoveryText;

    public string customSound;


}