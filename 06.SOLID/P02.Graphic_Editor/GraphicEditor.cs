namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private IShape shape;
        public GraphicEditor(IShape shape)
        {
            this.shape = shape;
        }
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}
