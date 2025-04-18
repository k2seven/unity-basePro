using UnityEngine;
using UnityEngine.UI;

public class ButtonCubeGenerator : MonoBehaviour
{
    public static int aa = 45;
    void Start()
    {

    }

    void Update()   
    {
      //点击则调用createCube方法
        if (Input.GetMouseButtonDown(0))    
        {
            CreateCube();
        }  
    }

    // 创建新的cube的方法
    void CreateCube()
    {
        // 创建一个基础的cube
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // 设置随机位置
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(0f, 5f);
        float z = Random.Range(-5f, 5f);
        cube.transform.position = new Vector3(x, y, z);
        
        // 设置随机旋转
        cube.transform.rotation = Random.rotation;
        
        // 设置随机颜色
        Renderer cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.color = new Color(
            Random.value, 
            Random.value, 
            Random.value
        );

        //cube做自由落体下落
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Rigidbody>().useGravity = true;
        
        //5s后销毁cube
        Destroy(cube, 5f);
    
    }
}
