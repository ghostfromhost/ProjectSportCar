namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Стратегия перемещения объекта к правому нижнему углу
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestinaion()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return false;
        // Цель достигнута, если правая граница объекта касается правого края,
        // а нижняя граница касается нижнего края (с учётом шага)
        return (FieldWidth - obj.RightBorder) <= GetStep() &&
               (FieldHeight - obj.DownBorder) <= GetStep();
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return;

        // Двигаемся вправо, если правая граница ещё не у края
        if (FieldWidth - obj.RightBorder > GetStep())
            MoveRight();
        else if (Math.Abs(FieldWidth - obj.RightBorder) > 0)
            // Если осталось меньше шага, но всё же не ноль, можно сделать ещё шаг
            MoveRight(); // но это может привести к выходу за границу? Проверка в MoveTransport отсечёт.

        // Двигаемся вниз, если нижняя граница ещё не у края
        if (FieldHeight - obj.DownBorder > GetStep())
            MoveDown();
        else if (Math.Abs(FieldHeight - obj.DownBorder) > 0)
            MoveDown();
    }
}