namespace P01.Stream_Progress
{
    public interface IStream
    {
        public int Length { get; }

        public int BytesSent { get; }
    }
}
