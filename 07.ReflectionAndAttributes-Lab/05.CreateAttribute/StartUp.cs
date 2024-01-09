namespace AuthorProblem
{
    [Author("Viktor")]
    public class StartUp
    {
        [Author("George")]
        [Author("Andon")]
        public static void Main()
        {
            var tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}