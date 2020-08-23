namespace MarsRover.Models
{
    public interface IPlateau
    {
        int GetHeight();
        int GetWidth();
        void SetHeight(int value);
        void SetWidth(int value);
        bool IsValidPoint(Position position);
    }
}