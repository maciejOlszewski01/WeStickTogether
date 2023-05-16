using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HoldingInteractable
{
    public bool stateChange { get; }
    public bool NotInteracting(Interactor interactor);
}
