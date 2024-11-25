public class SmallMap : Map{
    public SmallMap(int size) : base(size)
        {
            if (size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
            }
        }
}