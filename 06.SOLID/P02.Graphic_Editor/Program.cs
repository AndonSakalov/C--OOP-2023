namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape ract = new Octagon();
            GraphicEditor ge = new(ract);
            ge.DrawShape(ract);
        }
    }
}
