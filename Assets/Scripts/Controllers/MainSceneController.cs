using CobaltRoleplay.Enums;
using CobaltRoleplay.Models;
using CobaltRoleplay.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace CobaltRoleplay.Controllers
{
    public class MainSceneController : MonoBehaviour
    {

        bool IsLoaded;
        bool SceneElementsIsPositioned;
        bool startFinished;
        bool isPaused;
        bool IsGm;

        string SceneName = string.Empty;
        string SceneDescription = string.Empty;

        List<Token> tokens = new List<Token>();
        //List<GridImage> backgrounds = new List<GridImage>();
        List<GameObject> backgrounds = new List<GameObject>();


        SceneModel sceneModel;
        new Camera camera;


        //public GameObject gridManager;
        public GameObject backgroundType;

        GridController gridController;

        // Start is called before the first frame update
        async void Start()
        {
            IsLoaded = false;
            startFinished = false;

            Debug.Log("initializing");

            //gridController = gridManager.GetComponent<GridController>();

            camera = GetComponent<Camera>();

            //  TO-DO: Zona de pruebas que simula el cargado desde la nube

            sceneModel = new SceneModel()
            {
                IsGm = false,
                IsPaused = false,
                Tokens = new List<Token>(),
                Width = 800,
                Height = 600,
                Backgrounds = new List<GridImage>(),
                GridType = GridType.Square,
                InteractionStyle = InteractionStyle.DragAndDrop
            };
            sceneModel.Tokens.Add(new Token
            {
                SourceImageUrl = "https://media.discordapp.net/attachments/1075569658851242094/1120236087244242964/image.png?width=446&height=468",
                XPosition = 0,
                YPosition = 0,
            });


            sceneModel.Backgrounds.Add(new GridImage
            {
                Height = 600,
                Width = 600,
                SourceImageUrl = "https://media.discordapp.net/attachments/1075569658851242094/1120236087244242964/image.png?width=446&height=468",
                XPosition = -400f,
                YPosition = -200f,
            });

            //  Fin simulación

            //  Wait load resources
            var tasksBackgrounds = sceneModel.Backgrounds.Select(x => x.LoadSourceImage());
            var tasksTokens = sceneModel.Tokens.Select(x => x.LoadSourceImage());

            //gridController.Draw(sceneModel);


            await Task.WhenAll(tasksTokens);
            await Task.WhenAll(tasksBackgrounds);

            //  Configure gameobjects and positioning
            ToPositionGameObjects();

            startFinished = true;
            
        }

        

        public bool CheckIsLoaded()
        {


            if (IsLoaded) return true;

            else
            {
                foreach (var token in sceneModel.Tokens)
                    if (!token.ImageLoaded()) return false;

                foreach (var backgrounds in sceneModel.Backgrounds)
                    if (!backgrounds.ImageLoaded()) return false;

                IsLoaded = true;
                Debug.Log("Scene Loaded");
                return true;
            }
        }

        public bool CheckSceneElementsIsPositioned()
        {
            if (SceneElementsIsPositioned) return true;

            else
            {
                //temporal
                return false;
            }
        }


        
        // Update is called once per frame
        void Update()
        {
            if (!startFinished) return;

            if (!CheckIsLoaded()) return; 

            if (!CheckIsLoaded()) return;

            // ---

            if(sceneModel.IsGm || sceneModel.InteractionStyle == InteractionStyle.DragAndDrop) 
                PositionDynamicCamera();

            else PositionAnchoredCamera();




        }


        //  MoveKeys
        private void PositionAnchoredCamera()
        {
            throw new NotImplementedException();
        }


        //  Drag and drop
        private Vector3 velocity = Vector3.zero;
        void PositionDynamicCamera()
        {
            float panSpeed = 25000f;
            float scrollSpeed = 20000f;
            float minScroll = 60f;
            float maxScroll = 300f;
            float minY = sceneModel.Backgrounds.Select(x => x.YPosition).Min();
            float maxY = sceneModel.Backgrounds.Select(x => x.YPosition + x.Height).Max();
            float smoothTime = 0.5f;

            // camera control
            Vector3 targetPos = transform.position;

            if (Input.GetMouseButton(1)) 
            {
                targetPos.x -= Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
                targetPos.y -= Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll != 0)
            {
                camera.orthographicSize -= scroll * scrollSpeed * Time.deltaTime;
                camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minScroll, maxScroll);
            }


            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            // Suaviza el movimiento
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }



        private void ToPositionGameObjects()
        {

            foreach (var background in sceneModel.Backgrounds)
            {
                var gameObjTemp = Instantiate(backgroundType);
                gameObjTemp.GetComponent<BackgroundController>().SetBackGround(background);
            }

            //foreach (var Token in sceneModel.Tokens)
            //{
            //    var gameObjTemp = Instantiate(backgroundType);
            //    gameObjTemp.GetComponent<TokenController>().SetToken(Token);
            //}
        }
    }
}
