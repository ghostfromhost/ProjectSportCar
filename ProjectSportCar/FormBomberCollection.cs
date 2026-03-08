using ProjectSportCar.CollectionGenericObjects;
using ProjectSportCar.Drawnings;

namespace ProjectSportCar;

/// <summary>
/// Форма для работы с коллекцией
/// </summary>
public partial class FormBomberCollection : Form
{
	/// <summary>
	/// Компания
	/// </summary>
	private readonly AbstractCompany _company;

	/// <summary>
	/// Конструктор
	/// </summary>
	public FormBomberCollection()
	{
		InitializeComponent();
		_company = new Hangar(pictureBox.Width, pictureBox.Height, new MassiveGenericObjects<DrawningBomber>());
	}

	/// <summary>
	/// Добавление обычного автомобиля
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonAddBomber_Click(object sender, EventArgs e) => CreateAndAddObjectToCollection(nameof(DrawningBomber));

	/// <summary>
	/// Добавление спортивного автомобиля
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonAddUpgradedBomber_Click(object sender, EventArgs e) => CreateAndAddObjectToCollection(nameof(DrawningUpgradedBomber));

	/// <summary>
	/// Создание объекта класса-перемещения и добавление его в коллекцию
	/// </summary>
	/// <param name="type">Тип создаваемого объекта</param>
	private void CreateAndAddObjectToCollection(string type)
	{
		Random random = new();
		DrawningBomber bomber;
		switch (type)
		{
			case nameof(DrawningBomber):
				bomber = new DrawningBomber(random.Next(100, 300), random.Next(1000, 3000), GetColor(random));
				break;
			case nameof(DrawningUpgradedBomber):
				// TODO создание продвинутого объекта
				bomber = new DrawningUpgradedBomber(random.Next(100, 300), random.Next(1000, 3000), GetColor(random), GetColor(random), Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
				break;
			default:
				return;
		}

		if (_company + bomber)
		{
			MessageBox.Show("Объект добавлен");
			pictureBox.Image = _company.Show();
		}
		else
		{
			MessageBox.Show("Не удалось добавить объект");
		}
	}

	/// <summary>
	/// Получение цвета
	/// </summary>
	/// <param name="random">Генератор случайных чисел</param>
	/// <returns>Цвет</returns>
	private static Color GetColor(Random random)
	{
		ColorDialog dialog = new();
		return dialog.ShowDialog() == DialogResult.OK ?
			dialog.Color :
			Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
	}

	/// <summary>
	/// Удаление объекта
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonRemoveBomber_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(maskedTextBoxPosition.Text))
		{
			return;
		}

		if (MessageBox.Show("Удалить объект?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
		{
			return;
		}

		int pos = Convert.ToInt32(maskedTextBoxPosition.Text);
		if (_company - pos)
		{
			MessageBox.Show("Объект удален");
			pictureBox.Image = _company.Show();
		}
		else
		{
			MessageBox.Show("Не удалось удалить объект");
		}
	}

	/// <summary>
	/// Передача объекта в другую форму
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonGoToCheck_Click(object sender, EventArgs e)
	{
		if (_company.GetRandomObject() is not DrawningBomber bomber)
		{
			MessageBox.Show("Не удалось получить объект");
			return;
		}

		FormBomber formBomber = new();
		formBomber.SetBomber(bomber);
		formBomber.ShowDialog();
	}

	/// <summary>
	/// Перерисовка коллекции
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonRefresh_Click(object sender, EventArgs e) => pictureBox.Image = _company.Show();
}
