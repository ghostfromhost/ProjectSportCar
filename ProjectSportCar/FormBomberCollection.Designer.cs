namespace ProjectSportCar
{
	partial class FormBomberCollection
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBoxTools = new GroupBox();
			buttonRefresh = new Button();
			buttonAddUpgradedBomber = new Button();
			buttonGoToCheck = new Button();
			maskedTextBoxPosition = new MaskedTextBox();
			buttonAddBomber = new Button();
			buttonRemoveBomber = new Button();
			pictureBox = new PictureBox();
			groupBoxTools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			SuspendLayout();
			// 
			// groupBoxTools
			// 
			groupBoxTools.Controls.Add(buttonRefresh);
			groupBoxTools.Controls.Add(buttonAddUpgradedBomber);
			groupBoxTools.Controls.Add(buttonGoToCheck);
			groupBoxTools.Controls.Add(maskedTextBoxPosition);
			groupBoxTools.Controls.Add(buttonAddBomber);
			groupBoxTools.Controls.Add(buttonRemoveBomber);
			groupBoxTools.Dock = DockStyle.Right;
			groupBoxTools.Location = new Point(845, 0);
			groupBoxTools.Name = "groupBoxTools";
			groupBoxTools.Size = new Size(179, 616);
			groupBoxTools.TabIndex = 0;
			groupBoxTools.TabStop = false;
			groupBoxTools.Text = "Инструменты";
			// 
			// buttonRefresh
			// 
			buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			buttonRefresh.Location = new Point(6, 570);
			buttonRefresh.Name = "buttonRefresh";
			buttonRefresh.Size = new Size(167, 40);
			buttonRefresh.TabIndex = 6;
			buttonRefresh.Text = "Обновить";
			buttonRefresh.UseVisualStyleBackColor = true;
			buttonRefresh.Click += ButtonRefresh_Click;
			// 
			// buttonAddUpgradedBomber
			// 
			buttonAddUpgradedBomber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			buttonAddUpgradedBomber.Location = new Point(6, 68);
			buttonAddUpgradedBomber.Name = "buttonAddUpgradedBomber";
			buttonAddUpgradedBomber.Size = new Size(167, 40);
			buttonAddUpgradedBomber.TabIndex = 2;
			buttonAddUpgradedBomber.Text = "Добавление улучшенного бомбардировщика";
			buttonAddUpgradedBomber.UseVisualStyleBackColor = true;
			buttonAddUpgradedBomber.Click += ButtonAddUpgradedBomber_Click;
			// 
			// buttonGoToCheck
			// 
			buttonGoToCheck.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			buttonGoToCheck.Location = new Point(6, 524);
			buttonGoToCheck.Name = "buttonGoToCheck";
			buttonGoToCheck.Size = new Size(167, 40);
			buttonGoToCheck.TabIndex = 5;
			buttonGoToCheck.Text = "Передать на тесты";
			buttonGoToCheck.UseVisualStyleBackColor = true;
			buttonGoToCheck.Click += ButtonGoToCheck_Click;
			// 
			// maskedTextBoxPosition
			// 
			maskedTextBoxPosition.Location = new Point(6, 150);
			maskedTextBoxPosition.Mask = "00";
			maskedTextBoxPosition.Name = "maskedTextBoxPosition";
			maskedTextBoxPosition.Size = new Size(167, 23);
			maskedTextBoxPosition.TabIndex = 3;
			maskedTextBoxPosition.ValidatingType = typeof(int);
			// 
			// buttonAddBomber
			// 
			buttonAddBomber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			buttonAddBomber.Location = new Point(6, 22);
			buttonAddBomber.Name = "buttonAddBomber";
			buttonAddBomber.Size = new Size(167, 40);
			buttonAddBomber.TabIndex = 1;
			buttonAddBomber.Text = "Добавление бомбардировщика";
			buttonAddBomber.UseVisualStyleBackColor = true;
			buttonAddBomber.Click += ButtonAddBomber_Click;
			// 
			// buttonRemoveBomber
			// 
			buttonRemoveBomber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			buttonRemoveBomber.Location = new Point(6, 179);
			buttonRemoveBomber.Name = "buttonRemoveBomber";
			buttonRemoveBomber.Size = new Size(167, 40);
			buttonRemoveBomber.TabIndex = 4;
			buttonRemoveBomber.Text = "Удалить бомбардировщик";
			buttonRemoveBomber.UseVisualStyleBackColor = true;
			buttonRemoveBomber.Click += ButtonRemoveBomber_Click;
			// 
			// pictureBox
			// 
			pictureBox.Dock = DockStyle.Fill;
			pictureBox.Location = new Point(0, 0);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(845, 616);
			pictureBox.TabIndex = 1;
			pictureBox.TabStop = false;
			// 
			// FormCarCollection
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1024, 616);
			Controls.Add(pictureBox);
			Controls.Add(groupBoxTools);
			Name = "FormBomberCollection";
			Text = "Коллекция бомбардировщиков";
			groupBoxTools.ResumeLayout(false);
			groupBoxTools.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBoxTools;
		private Button buttonAddUpgradedBomber;
		private Button buttonAddBomber;
		private Button buttonRemoveBomber;
		private MaskedTextBox maskedTextBoxPosition;
		private PictureBox pictureBox;
		private Button buttonGoToCheck;
		private Button buttonRefresh;
	}
}