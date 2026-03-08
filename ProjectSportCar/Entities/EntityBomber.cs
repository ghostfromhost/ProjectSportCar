namespace ProjectSportCar.Entities;

/// <summary>
/// Класс-сущность "Бомбардировщик" (базовый, с двумя двигателями)
/// </summary>
public class EntityBomber
{
    /// <summary>Скорость</summary>
    public int Speed { get; init; }

    /// <summary>Вес</summary>
    public double Weight { get; init; }

    /// <summary>Основной цвет</summary>
    public Color BodyColor { get; init; }

    /// <summary>Количество двигателей (всегда 2)</summary>
    public int EngineCount => 2;

    /// <summary>Шаг перемещения</summary>
    public double Step => Speed * 100 / Weight;

    /// <summary>
    /// Конструктор
    /// </summary>
    public EntityBomber(int speed, double weight, Color bodyColor)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
    }
}