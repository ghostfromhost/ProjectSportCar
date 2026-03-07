namespace ProjectSportCar;

public partial class FormSportCar : Form
{
	/// <summary>
	/// ����-������ �������
	/// </summary>
	private readonly CanvasForCar _canvas;

	/// <summary>
	/// ���� ��� �������� ��������� ��� ���������� ���� �������� ������ �� �������
	/// </summary>
	private DirectionType _checkBordersState;

	/// <summary>
	/// ������������� �����
	/// </summary>
	public FormSportCar()
	{
		InitializeComponent();
		_canvas = new CanvasForCar();
		_canvas.SetPictureSize(pictureBoxSportCar.Width, pictureBoxSportCar.Height);
		_checkBordersState = DirectionType.None;
	}

    /// <summary>
    /// ����� ���������� ������
    /// </summary>
    private void Draw()
    {
        Image? oldImage = pictureBoxSportCar.Image;          // сохраняем ссылку на старое изображение
        pictureBoxSportCar.Image = _canvas.DrawCanvas();     // устанавливаем новое
        oldImage?.Dispose();                                  // освобождаем ресурсы старого
    }

    /// <summary>
    /// ��������� ������� ������ "�������"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonCreateCar_Click(object sender, EventArgs e)
	{
        Random random = new();
        DrawningCar car = new();

        // Генерация количества двигателей: 2, 4 или 6
        int engineCount = random.Next(1, 4) * 2; // 2,4,6
        System.Diagnostics.Debug.WriteLine($"Создан самолёт с {engineCount} двигателями");

        car.Init(
            random.Next(100, 300),
            random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)),
            engineCount
        );

        if (_canvas.InsertCar(car))
        {
            _canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100));
            Draw();
        }
    }

	/// <summary>
	/// ����������� ������� �� ����� (������� ������ ���������)
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonMove_Click(object sender, EventArgs e)
	{
		string name = ((Button)sender)?.Name ?? string.Empty;
		DirectionType direction = DirectionType.None;
		switch (name)
		{
			case "buttonUp":
				direction = DirectionType.Up;
				break;
			case "buttonDown":
				direction = DirectionType.Down;
				break;
			case "buttonLeft":
				direction = DirectionType.Left;
				break;
			case "buttonRight":
				direction = DirectionType.Right;
				break;
		}

		if (_canvas.MoveTransport(direction))
		{
			Draw();
		}
	}

	/// <summary>
	/// ��������, ��� ������ �� ������� �� ������� ��� ������� �������� �����������
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void ButtonCheckBorders_Click(object sender, EventArgs e)
	{
		Random random = new();
		switch (_checkBordersState)
		{
			case DirectionType.None:
			case DirectionType.Down:
				_canvas.SetCarPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
				_checkBordersState = DirectionType.Left;
				break;
			case DirectionType.Left:
				_canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
				_checkBordersState = DirectionType.Up;
				break;
			case DirectionType.Up:
				_canvas.SetCarPosition(random.Next(10, 100) + pictureBoxSportCar.Width, random.Next(10, 100));
				_checkBordersState = DirectionType.Right;
				break;
			case DirectionType.Right:
				_canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100) + pictureBoxSportCar.Height);
				_checkBordersState = DirectionType.Down;
				break;
		}

		Draw();
	}
}