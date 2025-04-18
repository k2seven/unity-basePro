using UnityEngine;
using XLua;

public class launch : MonoBehaviour
{
    public TextAsset script;
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString(script.bytes);
    }   
}
