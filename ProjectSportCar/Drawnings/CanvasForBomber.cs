namespace ProjectSportCar.Drawnings;

/// <summary>
/// Полотно для размещения и перемещения объекта
/// </summary>
public class CanvasForBomber
{
    private DrawningBomber? _drawningBomber;
    private int? _canvasWidth;
    private int? _canvasHeight;

    public DrawningBomber? DrawningBomber => _drawningBomber;

    public void SetPictureSize(int width, int height)
    {
        _canvasWidth = width;
        _canvasHeight = height;
    }

    public bool InsertBomber(DrawningBomber bomber)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            return false;
        if (bomber.DrawningWidth > _canvasWidth.Value || bomber.DrawningHeight > _canvasHeight.Value)
            return false;
        _drawningBomber = bomber;
        return true;
    }

    public void SetCarPosition(int x, int y)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningBomber is null)
            return;
        int newX = Math.Max(0, Math.Min(x, _canvasWidth.Value - _drawningBomber.DrawningWidth));
        int newY = Math.Max(0, Math.Min(y, _canvasHeight.Value - _drawningBomber.DrawningHeight));
        _drawningBomber.SetPosition(newX, newY);
    }

    public bool MoveTransport(DirectionType direction)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawningBomber is null ||
            !_drawningBomber.PosX.HasValue || !_drawningBomber.PosY.HasValue || !_drawningBomber.CarStep.HasValue)
            return false;

        switch (direction)
        {
            case DirectionType.Left:
                if (_drawningBomber.PosX.Value - _drawningBomber.CarStep.Value >= 0)
                {
                    _drawningBomber.MoveLeft();
                    return true;
                }
                break;
            case DirectionType.Up:
                if (_drawningBomber.PosY.Value - _drawningBomber.CarStep.Value >= 0)
                {
                    _drawningBomber.MoveUp();
                    return true;
                }
                break;
            case DirectionType.Right:
                if (_drawningBomber.PosX.Value + _drawningBomber.DrawningWidth + _drawningBomber.CarStep.Value <= _canvasWidth.Value)
                {
                    _drawningBomber.MoveRight();
                    return true;
                }
                break;
            case DirectionType.Down:
                if (_drawningBomber.PosY.Value + _drawningBomber.DrawningHeight + _drawningBomber.CarStep.Value <= _canvasHeight.Value)
                {
                    _drawningBomber.MoveDown();
                    return true;
                }
                break;
        }
        return false;
    }

    public Bitmap? DrawCanvas()
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            return null;
        Bitmap bmp = new(_canvasWidth.Value, _canvasHeight.Value);
        using (Graphics graphics = Graphics.FromImage(bmp))
        {
            _drawningBomber?.DrawTransport(graphics);
        }
        return bmp;
    }
}