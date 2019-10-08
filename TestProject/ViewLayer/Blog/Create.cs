namespace ViewLayer.Blog
{
    public class Create : Base
    {
        public string Title { get; set; }
        public ViewLayer.User.List CreatedBy { get; set; }
    }
}
