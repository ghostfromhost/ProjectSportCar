namespace ProjectSportCar.MovementTemplate;

/// <summary>
/// Фабрика по созданию экземпляра BaseTemplateMovement
/// </summary>
public static class TemplateMovementFactory
{
	/// <summary>
	/// Набор возможных ключей
	/// </summary>
	public static string[] Values => ["К центру", "К краю"];

	/// <summary>
	/// Создание экземпляра BaseTemplateMovement
	/// </summary>
	/// <param name="value">Значение, на основе которого будет создан экземпляр BaseTemplateMovement</param>
	/// <returns></returns>
	public static BaseTemplateMovement? CreateTemplateMovement(string value) => value switch
	{
		"К центру" => new MoveToCenter(),
		"К краю" => new MoveToRightDownBorder(),
		_ => null,
	};
}