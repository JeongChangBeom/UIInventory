using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIBase
{
    protected override UIState GetUIState()
    {
        return UIState.Inventory;
    }
}
