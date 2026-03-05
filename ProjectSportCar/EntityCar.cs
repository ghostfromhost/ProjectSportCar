namespace ProjectSportCar;

/// <summary>
/// Класс-сущность "Бомбардировщик"
/// </summary>
public class EntityCar
{
    /// <summary>
    /// Скорость
    /// </summary>
    public int Speed { get; private set; }

    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; private set; }

    /// <summary>
    /// Основной цвет
    /// </summary>
    public Color BodyColor { get; private set; }

    /// <summary>
    /// Количество двигателей (2, 4 или 6)
    /// </summary>
    public int EngineCount { get; private set; }

    /// <summary>
    /// Шаг перемещения самолёта
    /// </summary>
    public double Step => Speed * 100 / Weight;

    /// <summary>
    /// Инициализация полей объекта
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    /// <param name="engineCount">Количество двигателей</param>
    public void Init(int speed, double weight, Color bodyColor, int engineCount)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
        EngineCount = engineCount;
    }
}