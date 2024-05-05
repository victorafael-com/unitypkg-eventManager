# unitypkg-eventManager

Event Manager for Decentralized Unity Communication

## Usage:

### Recomendations:

First, Create one (or many) static class with string constants for naming your events.

Example:

```csharp
public static class EventDef {
    public const string COLLECT_ITEM = "COLLECT_ITEM";
    public const string SCORE_CHANGE = "SCORE_CHANGE";
    public const string NAME_SET = "NAME SET";
    public const string GAME_PAUSED = "GAME_PAUSED";
}
```

### Registering to events

You can register to events with no arguments or with int, string or object argument.

The example bellow shows a class registering for multiple types of events:

```csharp
using com.victorafael.events;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Register(EventDef.GAME_PAUSED, OnGamePaused);
        EventManager.Register(EventDef.NAME_SET, OnNameSet);
        EventManager.Register(EventDef.SCORE_CHANGE, OnScoreChanged);
        EventManager.RegisterObj(EventDef.COLLECT_ITEM, OnCollectItem);
    }

    void OnGamePaused()
    {
        Debug.Log("Game Paused");
    }
    void OnScoreChange(int newScore)
    {
        Debug.Log($"Score Changed: {newScore}");
    }
    void OnNameSet(string name)
    {
        Debug.Log($"Name Set: {name}");
    }
    void OnCollectItem(object obj)
    {
        Item item = (item) obj;
        Debug.Log($"Item collected: {item.name}");
        //Refresh item UI
    }
}
```

### Triggering events

To trigger those events, you can call the Trigger or TriggerObj method on EventManager

```csharp
using com.victorafael.events

...

private void OnPausePressed()
{
    EventManager.Trigger(EventDef.GAME_PAUSED);
}

...

void OnCollectItem(Item item){
    EventManager.TriggerObj(EventDef.COLLECT_ITEM, item);
    score += 10;
    EventManager.Trigger(EventDef.SCORE_CHANGED, score);
}
```
