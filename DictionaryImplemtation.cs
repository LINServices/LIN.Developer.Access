namespace LIN.Access.Developer;

public class ActionDictionary<TKey, TValue> : Dictionary<TKey, TValue>
{



    private Dictionary<TKey, Delegate> actions = [];




    // Indexador
    public TValue this[TKey clave]
    {
        get
        {
            if (base.ContainsKey(clave))
                return base[clave];

            return default!;
        }
        set
        {
            base[clave] = value;

            actions.TryGetValue(clave, out var @delegate);

            if (@delegate is not null)
                actions[clave].DynamicInvoke();
        }
    }

    public void SetAction(Delegate action, params TKey[] key)
    {
        foreach (var k in key)
        {
            if (actions.ContainsKey(k))
                actions[k] = action;
            else
                actions.Add(k, action);
        }

    }

}