namespace StringEditor
{
    public interface IStringEditor
    {
        void Insert(string value, int position);

        void Append(string value);

        void Delete(int startIndex, int count);

        void Replace(int startIndex, int count, string value);

        string Print();
    }
}
