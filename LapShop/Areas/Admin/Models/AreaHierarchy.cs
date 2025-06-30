namespace LapShop.Areas.Admin.Models
{
    public class UserDetailsVM
    {
        public string UserId { get; set; } = null!;
        public List<AreaGroup> AreaGroups { get; set; } = new List<AreaGroup>();
    }
    public class WebsiteTechnicalData
    {
        public WebsiteTechnicalData()
        {
            Area = "";
            Controller = "";
            Action = "";
            ReturnType = "";
            Attributes = "";
            IsSelected = false;
        }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ReturnType { get; set; }
        public string Attributes { get; set; }
        public bool IsSelected { get; set; }
    }
    public class AreaGroup
    {
        public AreaGroup()
        {
            Area = "";
            Controllers = new List<ControllerActionGroup>();
            SelectedActions = new List<string>();
        }
        public string Area { get; set; }
        public List<ControllerActionGroup> Controllers { get; set; }
        public List<string> SelectedActions { get; set; }
    }
    public class ControllerActionGroup
    {
        public ControllerActionGroup()
        {
            Controller = "";
            TechnicalData = new List<WebsiteTechnicalData>();
        }
        public string Controller { get; set; }
        public List<WebsiteTechnicalData> TechnicalData { get; set; }
    }
}
