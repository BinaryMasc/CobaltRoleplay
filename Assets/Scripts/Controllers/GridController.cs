using CobaltRoleplay.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public GameObject Line;
    public GameObject GridSquare;
    public GameObject GridHex;

    public float GridWidth = 50;
    public float GridHeight = 50;

    bool isLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        isLoaded = true;
    }

    public void Draw(SceneModel sceneConfig)
    {


        if (sceneConfig.GridType == CobaltRoleplay.Enums.GridType.Square)
            DrawSquares(sceneConfig);
    }

    void DrawSquares(SceneModel sceneConfig)
    {

        float minY = sceneConfig.Backgrounds.Select(x => x.YPosition).Min();
        float minX = sceneConfig.Backgrounds.Select(x => x.XPosition).Min();

        Debug.Log(minY);
        Debug.Log(minX);


        for (int i = 0; i < 100; i++)
        {
            var lineY = Instantiate(Line, new Vector3(minX , ((i * GridHeight) / 2) - minY + Mathf.Abs(minY) * -2), new Quaternion(), transform);
            lineY.transform.localScale = new Vector3(50 * 20 * 2, 1);

            var lineX = Instantiate(Line, new Vector3(((i * GridHeight) / 2) - minX + Mathf.Abs(minX) * -2, minY), new Quaternion(), transform);
            lineX.transform.localScale = new Vector3(1, 50 * 20 * 2);
        }

        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                var square = Instantiate(GridSquare, new Vector3(i * GridWidth / 2, j * GridHeight / 2), new Quaternion(), transform);
                square.transform.localScale = new Vector3(GridWidth, GridHeight);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!isLoaded) return;
    }
}
