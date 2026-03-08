using ProjectSportCar.Drawnings;

namespace ProjectSportCar.MovementTemplate;

public class MoveableAdapterBomber : IMoveableObject
{
    private readonly DrawningBomber _bomber;

    public MoveableAdapterBomber(DrawningBomber bomber)
    {
        _bomber = bomber;
    }

    public ObjectCoordinates? ObjectCoordinates
    {
        get
        {
            if (_bomber is null || !_bomber.PosX.HasValue || !_bomber.PosY.HasValue)
                return null;
            return new ObjectCoordinates(_bomber.PosX.Value, _bomber.PosY.Value,
                                         _bomber.DrawningWidth, _bomber.DrawningHeight);
        }
    }

    public int ObjectStep => (int)(_bomber?.CarStep ?? 0);

    public void MoveObject(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Left: _bomber?.MoveLeft(); break;
            case MovementDirection.Up: _bomber?.MoveUp(); break;
            case MovementDirection.Right: _bomber?.MoveRight(); break;
            case MovementDirection.Down: _bomber?.MoveDown(); break;
        }
    }

    public void SetObjectPosition(int x, int y) => _bomber?.SetPosition(x, y);
    public void DrawObject(Graphics graphics) => _bomber?.DrawTransport(graphics);
}