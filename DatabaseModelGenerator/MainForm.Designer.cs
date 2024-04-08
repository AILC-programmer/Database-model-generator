namespace DatabaseModelGenerator
{
    partial class MainForm
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
            this.DataSourceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DatabasesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DBConnectionButton = new System.Windows.Forms.Button();
            this.TablesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.TablesReaderProgressBar = new System.Windows.Forms.ProgressBar();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.UsernameIDTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RootNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SecondryNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TableTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PrimaryKeyTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComputedColumnTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IdentityColumnTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.AllowNullTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.MaxLengthTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RepositoryInterfaceTextBox = new System.Windows.Forms.TextBox();
            this.ModelGeneratingProgressBar = new System.Windows.Forms.ProgressBar();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.UniqueAttributeTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.UserIDCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveModelButton = new System.Windows.Forms.Button();
            this.OpenModelButton = new System.Windows.Forms.Button();
            this.ItemsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.DataSourceTextBox.ForeColor = System.Drawing.Color.White;
            this.DataSourceTextBox.Location = new System.Drawing.Point(84, 14);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(111, 25);
            this.DataSourceTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data source";
            // 
            // DatabasesComboBox
            // 
            this.DatabasesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabasesComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.DatabasesComboBox.ForeColor = System.Drawing.Color.White;
            this.DatabasesComboBox.FormattingEnabled = true;
            this.DatabasesComboBox.Location = new System.Drawing.Point(84, 44);
            this.DatabasesComboBox.Name = "DatabasesComboBox";
            this.DatabasesComboBox.Size = new System.Drawing.Size(539, 25);
            this.DatabasesComboBox.TabIndex = 8;
            this.DatabasesComboBox.SelectedIndexChanged += new System.EventHandler(this.DatabasesComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Databases";
            // 
            // DBConnectionButton
            // 
            this.DBConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DBConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.DBConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DBConnectionButton.Location = new System.Drawing.Point(629, 14);
            this.DBConnectionButton.Name = "DBConnectionButton";
            this.DBConnectionButton.Size = new System.Drawing.Size(82, 21);
            this.DBConnectionButton.TabIndex = 6;
            this.DBConnectionButton.Text = "Connect...";
            this.DBConnectionButton.UseVisualStyleBackColor = false;
            this.DBConnectionButton.Click += new System.EventHandler(this.DBConnectionButton_Click);
            // 
            // TablesCheckedListBox
            // 
            this.TablesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablesCheckedListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.TablesCheckedListBox.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TablesCheckedListBox.ForeColor = System.Drawing.Color.White;
            this.TablesCheckedListBox.FormattingEnabled = true;
            this.TablesCheckedListBox.Location = new System.Drawing.Point(13, 75);
            this.TablesCheckedListBox.Name = "TablesCheckedListBox";
            this.TablesCheckedListBox.Size = new System.Drawing.Size(698, 284);
            this.TablesCheckedListBox.TabIndex = 10;
            // 
            // TablesReaderProgressBar
            // 
            this.TablesReaderProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TablesReaderProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(200)))));
            this.TablesReaderProgressBar.Location = new System.Drawing.Point(629, 50);
            this.TablesReaderProgressBar.MarqueeAnimationSpeed = 50;
            this.TablesReaderProgressBar.Name = "TablesReaderProgressBar";
            this.TablesReaderProgressBar.Size = new System.Drawing.Size(82, 13);
            this.TablesReaderProgressBar.Step = 5;
            this.TablesReaderProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.TablesReaderProgressBar.TabIndex = 9;
            this.TablesReaderProgressBar.Visible = false;
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Location = new System.Drawing.Point(630, 369);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(81, 21);
            this.SelectAllCheckBox.TabIndex = 11;
            this.SelectAllCheckBox.Text = "Select all";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBox_CheckedChanged);
            // 
            // UsernameIDTextBox
            // 
            this.UsernameIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.UsernameIDTextBox.Enabled = false;
            this.UsernameIDTextBox.ForeColor = System.Drawing.Color.White;
            this.UsernameIDTextBox.Location = new System.Drawing.Point(284, 14);
            this.UsernameIDTextBox.Name = "UsernameIDTextBox";
            this.UsernameIDTextBox.Size = new System.Drawing.Size(141, 25);
            this.UsernameIDTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(494, 14);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(129, 25);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(431, 17);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(65, 17);
            this.password.TabIndex = 4;
            this.password.Text = "password";
            this.password.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Root namespace";
            // 
            // RootNamespaceTextBox
            // 
            this.RootNamespaceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.RootNamespaceTextBox.ForeColor = System.Drawing.Color.White;
            this.RootNamespaceTextBox.Location = new System.Drawing.Point(101, 0);
            this.RootNamespaceTextBox.Name = "RootNamespaceTextBox";
            this.RootNamespaceTextBox.Size = new System.Drawing.Size(128, 25);
            this.RootNamespaceTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Secondry namespace";
            // 
            // SecondryNamespaceTextBox
            // 
            this.SecondryNamespaceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.SecondryNamespaceTextBox.ForeColor = System.Drawing.Color.White;
            this.SecondryNamespaceTextBox.Location = new System.Drawing.Point(358, 0);
            this.SecondryNamespaceTextBox.Name = "SecondryNamespaceTextBox";
            this.SecondryNamespaceTextBox.Size = new System.Drawing.Size(128, 25);
            this.SecondryNamespaceTextBox.TabIndex = 3;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.GenerateButton.Enabled = false;
            this.GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateButton.Location = new System.Drawing.Point(636, 527);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 14;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Table";
            // 
            // TableTextBox
            // 
            this.TableTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.TableTextBox.ForeColor = System.Drawing.Color.White;
            this.TableTextBox.Location = new System.Drawing.Point(43, 40);
            this.TableTextBox.Name = "TableTextBox";
            this.TableTextBox.Size = new System.Drawing.Size(68, 25);
            this.TableTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(697, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "----------------------------------------------------------------------------Attri" +
    "butes---------------------------------------------------------------------------" +
    "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Primary key";
            // 
            // PrimaryKeyTextBox
            // 
            this.PrimaryKeyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.PrimaryKeyTextBox.ForeColor = System.Drawing.Color.White;
            this.PrimaryKeyTextBox.Location = new System.Drawing.Point(187, 40);
            this.PrimaryKeyTextBox.Name = "PrimaryKeyTextBox";
            this.PrimaryKeyTextBox.Size = new System.Drawing.Size(98, 25);
            this.PrimaryKeyTextBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Computed";
            // 
            // ComputedColumnTextBox
            // 
            this.ComputedColumnTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.ComputedColumnTextBox.ForeColor = System.Drawing.Color.White;
            this.ComputedColumnTextBox.Location = new System.Drawing.Point(358, 40);
            this.ComputedColumnTextBox.Name = "ComputedColumnTextBox";
            this.ComputedColumnTextBox.Size = new System.Drawing.Size(131, 25);
            this.ComputedColumnTextBox.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Identity";
            // 
            // IdentityColumnTextBox
            // 
            this.IdentityColumnTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.IdentityColumnTextBox.ForeColor = System.Drawing.Color.White;
            this.IdentityColumnTextBox.Location = new System.Drawing.Point(547, 40);
            this.IdentityColumnTextBox.Name = "IdentityColumnTextBox";
            this.IdentityColumnTextBox.Size = new System.Drawing.Size(131, 25);
            this.IdentityColumnTextBox.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Allow null";
            // 
            // AllowNullTextBox
            // 
            this.AllowNullTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.AllowNullTextBox.ForeColor = System.Drawing.Color.White;
            this.AllowNullTextBox.Location = new System.Drawing.Point(68, 67);
            this.AllowNullTextBox.Name = "AllowNullTextBox";
            this.AllowNullTextBox.Size = new System.Drawing.Size(113, 25);
            this.AllowNullTextBox.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Max length";
            // 
            // MaxLengthTextBox
            // 
            this.MaxLengthTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.MaxLengthTextBox.ForeColor = System.Drawing.Color.White;
            this.MaxLengthTextBox.Location = new System.Drawing.Point(258, 67);
            this.MaxLengthTextBox.Name = "MaxLengthTextBox";
            this.MaxLengthTextBox.Size = new System.Drawing.Size(113, 25);
            this.MaxLengthTextBox.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(377, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "Repository interface";
            // 
            // RepositoryInterfaceTextBox
            // 
            this.RepositoryInterfaceTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.RepositoryInterfaceTextBox.ForeColor = System.Drawing.Color.White;
            this.RepositoryInterfaceTextBox.Location = new System.Drawing.Point(493, 67);
            this.RepositoryInterfaceTextBox.Name = "RepositoryInterfaceTextBox";
            this.RepositoryInterfaceTextBox.Size = new System.Drawing.Size(185, 25);
            this.RepositoryInterfaceTextBox.TabIndex = 17;
            // 
            // ModelGeneratingProgressBar
            // 
            this.ModelGeneratingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModelGeneratingProgressBar.Location = new System.Drawing.Point(13, 527);
            this.ModelGeneratingProgressBar.MarqueeAnimationSpeed = 50;
            this.ModelGeneratingProgressBar.Maximum = 50;
            this.ModelGeneratingProgressBar.Name = "ModelGeneratingProgressBar";
            this.ModelGeneratingProgressBar.Size = new System.Drawing.Size(421, 23);
            this.ModelGeneratingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ModelGeneratingProgressBar.TabIndex = 13;
            this.ModelGeneratingProgressBar.Visible = false;
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsPanel.Controls.Add(this.RepositoryInterfaceTextBox);
            this.ItemsPanel.Controls.Add(this.label12);
            this.ItemsPanel.Controls.Add(this.MaxLengthTextBox);
            this.ItemsPanel.Controls.Add(this.label11);
            this.ItemsPanel.Controls.Add(this.UniqueAttributeTextBox);
            this.ItemsPanel.Controls.Add(this.label13);
            this.ItemsPanel.Controls.Add(this.AllowNullTextBox);
            this.ItemsPanel.Controls.Add(this.label10);
            this.ItemsPanel.Controls.Add(this.IdentityColumnTextBox);
            this.ItemsPanel.Controls.Add(this.label9);
            this.ItemsPanel.Controls.Add(this.ComputedColumnTextBox);
            this.ItemsPanel.Controls.Add(this.label8);
            this.ItemsPanel.Controls.Add(this.PrimaryKeyTextBox);
            this.ItemsPanel.Controls.Add(this.label7);
            this.ItemsPanel.Controls.Add(this.label6);
            this.ItemsPanel.Controls.Add(this.TableTextBox);
            this.ItemsPanel.Controls.Add(this.label5);
            this.ItemsPanel.Controls.Add(this.SecondryNamespaceTextBox);
            this.ItemsPanel.Controls.Add(this.label4);
            this.ItemsPanel.Controls.Add(this.RootNamespaceTextBox);
            this.ItemsPanel.Controls.Add(this.label3);
            this.ItemsPanel.Location = new System.Drawing.Point(14, 396);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(697, 125);
            this.ItemsPanel.TabIndex = 12;
            this.ItemsPanel.Visible = false;
            // 
            // UniqueAttributeTextBox
            // 
            this.UniqueAttributeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.UniqueAttributeTextBox.ForeColor = System.Drawing.Color.White;
            this.UniqueAttributeTextBox.Location = new System.Drawing.Point(68, 94);
            this.UniqueAttributeTextBox.Name = "UniqueAttributeTextBox";
            this.UniqueAttributeTextBox.Size = new System.Drawing.Size(113, 25);
            this.UniqueAttributeTextBox.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "Unique";
            // 
            // UserIDCheckBox
            // 
            this.UserIDCheckBox.AutoSize = true;
            this.UserIDCheckBox.Location = new System.Drawing.Point(201, 16);
            this.UserIDCheckBox.Name = "UserIDCheckBox";
            this.UserIDCheckBox.Size = new System.Drawing.Size(89, 21);
            this.UserIDCheckBox.TabIndex = 2;
            this.UserIDCheckBox.Text = "Username";
            this.UserIDCheckBox.UseVisualStyleBackColor = true;
            this.UserIDCheckBox.CheckedChanged += new System.EventHandler(this.UserIDCheckBox_CheckedChanged);
            // 
            // SaveModelButton
            // 
            this.SaveModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveModelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.SaveModelButton.Enabled = false;
            this.SaveModelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveModelButton.Location = new System.Drawing.Point(538, 527);
            this.SaveModelButton.Name = "SaveModelButton";
            this.SaveModelButton.Size = new System.Drawing.Size(92, 23);
            this.SaveModelButton.TabIndex = 14;
            this.SaveModelButton.Text = "Save model";
            this.SaveModelButton.UseVisualStyleBackColor = false;
            this.SaveModelButton.Click += new System.EventHandler(this.SaveModelButton_Click);
            // 
            // OpenModelButton
            // 
            this.OpenModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenModelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(100)))));
            this.OpenModelButton.Enabled = false;
            this.OpenModelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenModelButton.Location = new System.Drawing.Point(440, 527);
            this.OpenModelButton.Name = "OpenModelButton";
            this.OpenModelButton.Size = new System.Drawing.Size(92, 23);
            this.OpenModelButton.TabIndex = 14;
            this.OpenModelButton.Text = "Open model";
            this.OpenModelButton.UseVisualStyleBackColor = false;
            this.OpenModelButton.Click += new System.EventHandler(this.OpenModelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(98)))));
            this.ClientSize = new System.Drawing.Size(722, 564);
            this.Controls.Add(this.ModelGeneratingProgressBar);
            this.Controls.Add(this.UserIDCheckBox);
            this.Controls.Add(this.ItemsPanel);
            this.Controls.Add(this.SelectAllCheckBox);
            this.Controls.Add(this.TablesReaderProgressBar);
            this.Controls.Add(this.TablesCheckedListBox);
            this.Controls.Add(this.DBConnectionButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DatabasesComboBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameIDTextBox);
            this.Controls.Add(this.DataSourceTextBox);
            this.Controls.Add(this.OpenModelButton);
            this.Controls.Add(this.SaveModelButton);
            this.Controls.Add(this.GenerateButton);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(738, 603);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ItemsPanel.ResumeLayout(false);
            this.ItemsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DatabasesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DBConnectionButton;
        private System.Windows.Forms.CheckedListBox TablesCheckedListBox;
        private System.Windows.Forms.ProgressBar TablesReaderProgressBar;
        private System.Windows.Forms.CheckBox SelectAllCheckBox;
        private System.Windows.Forms.TextBox UsernameIDTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RootNamespaceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SecondryNamespaceTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TableTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PrimaryKeyTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ComputedColumnTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox IdentityColumnTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox AllowNullTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MaxLengthTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox RepositoryInterfaceTextBox;
        private System.Windows.Forms.ProgressBar ModelGeneratingProgressBar;
        private System.Windows.Forms.Panel ItemsPanel;
        private System.Windows.Forms.CheckBox UserIDCheckBox;
        private System.Windows.Forms.TextBox UniqueAttributeTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button SaveModelButton;
        private System.Windows.Forms.Button OpenModelButton;
    }
}

