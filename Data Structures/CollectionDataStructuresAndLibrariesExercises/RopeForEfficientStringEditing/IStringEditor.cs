namespace RopeForEfficientStringEditing
{
    public interface IStringEditor
    {
        void Insert(string value);

        void Append(string value);

        void Delete(int startIndex, int count);

        string Print();
    }
}
