namespace FormBuilder.Shared.Kernel.Pagination
{
    public class PageFilter
    {
        public PageFilter(int number, int size)
        {
            Number = number;
            Size = size;
        }

        public int Number { get; protected set; }
        public int Size { get; protected set; }
    }
}
