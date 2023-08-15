namespace CobaltRoleplay.Models
{
    public class LoadSceneModel
    {
        public LoadSceneModel() { }

        public bool IsLoaded { get; set; }
        public bool isPaused { get; set; }
        public bool IsGm { get; set; }


        public string SceneName { get; set; } = string.Empty;
        public string SceneDescription { get; set; } = string.Empty;
    }
}