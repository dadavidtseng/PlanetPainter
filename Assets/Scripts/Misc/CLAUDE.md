# Misc

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Misc/`

Shared utilities and base classes.

## UI_SetAppear — Base UI Visibility

```csharp
public class UI_SetAppear : MonoBehaviour {
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform groupTrans;

    protected void SetAppear(bool IsOn);
}
```

DOTween animations: scale (0.5s in with OutBack, 0.3s out) + fade. Used by `UI_Pause`, `UI_Result`, `UI_Setting`, `UI_Credit`, `UI_Quit`, `UI_Menu`, `UI_StoryBoard`, `NotifyView`.

## ConsoleScriptableObject

```csharp
[CreateAssetMenu(fileName = "ConsoleData_SO", menuName = "Data/ConsoleData_SO")]
public class ConsoleScriptableObject : ScriptableObject {
    public ConsoleSettings consoleSettings;
}

public class ConsoleSettings {
    public bool printOnGameStateChanged;
    public bool printOnPlayerStateChanged;
    public bool printOnPlayerColorChanged;
}
```

Injected into state handlers for conditional debug logging.

## Dependencies

- DOTween
- Assembly: `Project.Misc`
