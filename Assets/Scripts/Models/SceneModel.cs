using CobaltRoleplay.Enums;
using CobaltRoleplay.Objects;
using System.Collections.Generic;
using Unity.Mathematics;

namespace CobaltRoleplay.Models
{
    public class SceneModel
    {
        public SceneModel() { }

        public bool IsPaused { get; set; }
        public bool IsGm { get; set; }

        public int name { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }

        public InteractionStyle InteractionStyle { get; set; }
        public GridType GridType { get; set; }



        public List<Token> Tokens { get; set; }
        public List<GridImage> Backgrounds { get; set; }
        //public List<GameElements> SceneElements { get; set; }
    }
}