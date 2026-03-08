using ProjectSportCar.Drawnings;
using ProjectSportCar.MovementTemplate;

namespace ProjectSportCar;

public partial class FormBomber : Form
{
    private readonly CanvasForBomber _canvas;
    private DirectionType _checkBordersState;
    private BaseTemplateMovement? _templateMovement;

    public FormBomber()
    {
        InitializeComponent();
        _canvas = new CanvasForBomber();
        _canvas.SetPictureSize(pictureBoxSportCar.Width, pictureBoxSportCar.Height);
        _checkBordersState = DirectionType.None;
        _templateMovement = null;
    }

    private void Draw()
    {
        Image? oldImage = pictureBoxSportCar.Image;
        pictureBoxSportCar.Image = _canvas.DrawCanvas();
        oldImage?.Dispose();
    }

    private void ButtonCreateBomber_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningBomber));

    private void ButtonCreateUpgradedBomber_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningUpgradedBomber));

    private void CreateObject(string type)
    {
        Random random = new();
        DrawningBomber? bomber = null;

        switch (type)
        {
            case nameof(DrawningBomber):
                bomber = new DrawningBomber(
                    random.Next(100, 300),
                    random.Next(1000, 3000),
                    Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))
                );
                break;

            case nameof(DrawningUpgradedBomber):
                bomber = new DrawningUpgradedBomber(
                    random.Next(100, 300),
                    random.Next(1000, 3000),
                    Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
                    Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
                    true,
                    true
                );
                break;
        }

        if (bomber != null && _canvas.InsertCar(bomber))
        {
            _canvas.SetCarPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxPointOfDestination.Enabled = true;
            comboBoxPointOfDestination.SelectedIndex = -1;
            Draw();
        }
    }

    private void ButtonMove_Click(object sender, EventArgs e)
    {
        string name = ((Button)sender)?.Name ?? string.Empty;
        DirectionType direction = DirectionType.None;
        switch (name)
        {
            case "buttonUp": direction = DirectionType.Up; break;
            case "buttonDown": direction = DirectionType.Down; break;
            case "buttonLeft": direction = DirectionType.Left; break;
            case "buttonRight": direction = DirectionType.Right; break;
        }

        if (_canvas.MoveTransport(direction))
            Draw();
    }

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

    private void ComboBoxPointOfDestination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_canvas is null || _canvas.DrawningBomber is null)
            return;

        _templateMovement = comboBoxPointOfDestination.SelectedIndex switch
        {
            0 => new MoveToCenter(),
            1 => new MoveToRightDownBorder(),
            _ => null
        };

        if (_templateMovement is null)
            return;

        _templateMovement.SetData(new MoveableAdapterBomber(_canvas.DrawningBomber),
                                  pictureBoxSportCar.Width,
                                  pictureBoxSportCar.Height);
        comboBoxPointOfDestination.Enabled = false;
    }

    private void ButtonMovementStep_Click(object sender, EventArgs e)
    {
        if (_templateMovement is null)
            return;

        _templateMovement.MakeStep();
        if (_templateMovement.IsFinishReached)
        {
            comboBoxPointOfDestination.Enabled = true;
            comboBoxPointOfDestination.SelectedIndex = -1;
        }
        Draw();
    }
}