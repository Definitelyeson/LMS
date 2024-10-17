namespace LMS.View
{
    partial class FrmBookBorrowing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBookBorrowing));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.cmbCategory = new Bunifu.UI.WinForms.BunifuDropdown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelPage = new Bunifu.UI.WinForms.BunifuLabel();
            this.BtnNext = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.BtnPrev = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1176, 576);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 45);
            this.panel1.TabIndex = 26;
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = false;
            this.txtSearch.AcceptsTab = false;
            this.txtSearch.AnimationSpeed = 200;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSearch.AutoSizeHeight = true;
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtSearch.BorderRadius = 1;
            this.txtSearch.BorderThickness = 1;
            this.txtSearch.CharacterCase = Bunifu.UI.WinForms.BunifuTextBox.CharacterCases.Normal;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.HideSelection = true;
            this.txtSearch.IconLeft = null;
            this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.IconPadding = 10;
            this.txtSearch.IconRight = global::LMS.Properties.Resources.image_4;
            this.txtSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(899, 5);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtSearch.Modified = false;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnIdleState = stateProperties4;
            this.txtSearch.Padding = new System.Windows.Forms.Padding(3);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.PlaceholderText = "Search Books";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(226, 34);
            this.txtSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.TextMarginBottom = 0;
            this.txtSearch.TextMarginLeft = 3;
            this.txtSearch.TextMarginTop = 1;
            this.txtSearch.TextPlaceholder = "Search Books";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WordWrap = true;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbCategory.BackgroundColor = System.Drawing.Color.White;
            this.cmbCategory.BorderColor = System.Drawing.Color.Silver;
            this.cmbCategory.BorderRadius = 1;
            this.cmbCategory.Color = System.Drawing.Color.Silver;
            this.cmbCategory.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbCategory.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCategory.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbCategory.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbCategory.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbCategory.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCategory.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCategory.FillDropDown = true;
            this.cmbCategory.FillIndicator = false;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategory.ForeColor = System.Drawing.Color.Black;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Icon = null;
            this.cmbCategory.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCategory.IndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbCategory.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbCategory.IndicatorThickness = 2;
            this.cmbCategory.IsDropdownOpened = false;
            this.cmbCategory.ItemBackColor = System.Drawing.Color.White;
            this.cmbCategory.ItemBorderColor = System.Drawing.Color.White;
            this.cmbCategory.ItemForeColor = System.Drawing.Color.Black;
            this.cmbCategory.ItemHeight = 26;
            this.cmbCategory.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cmbCategory.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cmbCategory.ItemTopMargin = 3;
            this.cmbCategory.Location = new System.Drawing.Point(26, 7);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(135, 32);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Text = "Category";
            this.cmbCategory.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbCategory.TextLeftMargin = 5;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabelPage);
            this.panel2.Controls.Add(this.BtnNext);
            this.panel2.Controls.Add(this.BtnPrev);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 621);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1176, 40);
            this.panel2.TabIndex = 27;
            // 
            // LabelPage
            // 
            this.LabelPage.AllowParentOverrides = false;
            this.LabelPage.AutoEllipsis = false;
            this.LabelPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.LabelPage.CursorType = System.Windows.Forms.Cursors.Default;
            this.LabelPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LabelPage.Location = new System.Drawing.Point(565, 12);
            this.LabelPage.Name = "LabelPage";
            this.LabelPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelPage.Size = new System.Drawing.Size(26, 15);
            this.LabelPage.TabIndex = 5;
            this.LabelPage.Text = "Page";
            this.LabelPage.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.LabelPage.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BtnNext
            // 
            this.BtnNext.AllowAnimations = true;
            this.BtnNext.AllowMouseEffects = true;
            this.BtnNext.AllowToggling = false;
            this.BtnNext.AnimationSpeed = 200;
            this.BtnNext.AutoGenerateColors = false;
            this.BtnNext.AutoRoundBorders = true;
            this.BtnNext.AutoSizeLeftIcon = true;
            this.BtnNext.AutoSizeRightIcon = true;
            this.BtnNext.BackColor = System.Drawing.Color.Transparent;
            this.BtnNext.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.BtnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnNext.BackgroundImage")));
            this.BtnNext.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNext.ButtonText = "Next Page";
            this.BtnNext.ButtonTextMarginLeft = 0;
            this.BtnNext.ColorContrastOnClick = 45;
            this.BtnNext.ColorContrastOnHover = 45;
            this.BtnNext.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.BtnNext.CustomizableEdges = borderEdges1;
            this.BtnNext.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnNext.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnNext.DisabledFillColor = System.Drawing.Color.Empty;
            this.BtnNext.DisabledForecolor = System.Drawing.Color.Empty;
            this.BtnNext.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnNext.ForeColor = System.Drawing.Color.White;
            this.BtnNext.IconLeft = null;
            this.BtnNext.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNext.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnNext.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnNext.IconMarginLeft = 11;
            this.BtnNext.IconPadding = 10;
            this.BtnNext.IconRight = null;
            this.BtnNext.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNext.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnNext.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnNext.IconSize = 25;
            this.BtnNext.IdleBorderColor = System.Drawing.Color.Empty;
            this.BtnNext.IdleBorderRadius = 0;
            this.BtnNext.IdleBorderThickness = 0;
            this.BtnNext.IdleFillColor = System.Drawing.Color.Empty;
            this.BtnNext.IdleIconLeftImage = null;
            this.BtnNext.IdleIconRightImage = null;
            this.BtnNext.IndicateFocus = false;
            this.BtnNext.Location = new System.Drawing.Point(642, 6);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnNext.OnDisabledState.BorderRadius = 25;
            this.BtnNext.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNext.OnDisabledState.BorderThickness = 1;
            this.BtnNext.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnNext.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnNext.OnDisabledState.IconLeftImage = null;
            this.BtnNext.OnDisabledState.IconRightImage = null;
            this.BtnNext.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnNext.onHoverState.BorderRadius = 25;
            this.BtnNext.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNext.onHoverState.BorderThickness = 1;
            this.BtnNext.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnNext.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnNext.onHoverState.IconLeftImage = null;
            this.BtnNext.onHoverState.IconRightImage = null;
            this.BtnNext.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnNext.OnIdleState.BorderRadius = 25;
            this.BtnNext.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNext.OnIdleState.BorderThickness = 1;
            this.BtnNext.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.BtnNext.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnNext.OnIdleState.IconLeftImage = null;
            this.BtnNext.OnIdleState.IconRightImage = null;
            this.BtnNext.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnNext.OnPressedState.BorderRadius = 25;
            this.BtnNext.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnNext.OnPressedState.BorderThickness = 1;
            this.BtnNext.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnNext.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnNext.OnPressedState.IconLeftImage = null;
            this.BtnNext.OnPressedState.IconRightImage = null;
            this.BtnNext.Size = new System.Drawing.Size(104, 25);
            this.BtnNext.TabIndex = 4;
            this.BtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnNext.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnNext.TextMarginLeft = 0;
            this.BtnNext.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnNext.UseDefaultRadiusAndThickness = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.AllowAnimations = true;
            this.BtnPrev.AllowMouseEffects = true;
            this.BtnPrev.AllowToggling = false;
            this.BtnPrev.AnimationSpeed = 200;
            this.BtnPrev.AutoGenerateColors = false;
            this.BtnPrev.AutoRoundBorders = true;
            this.BtnPrev.AutoSizeLeftIcon = true;
            this.BtnPrev.AutoSizeRightIcon = true;
            this.BtnPrev.BackColor = System.Drawing.Color.Transparent;
            this.BtnPrev.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.BtnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPrev.BackgroundImage")));
            this.BtnPrev.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrev.ButtonText = "Previous Page";
            this.BtnPrev.ButtonTextMarginLeft = 0;
            this.BtnPrev.ColorContrastOnClick = 45;
            this.BtnPrev.ColorContrastOnHover = 45;
            this.BtnPrev.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.BtnPrev.CustomizableEdges = borderEdges2;
            this.BtnPrev.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BtnPrev.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnPrev.DisabledFillColor = System.Drawing.Color.Empty;
            this.BtnPrev.DisabledForecolor = System.Drawing.Color.Empty;
            this.BtnPrev.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.BtnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnPrev.ForeColor = System.Drawing.Color.White;
            this.BtnPrev.IconLeft = null;
            this.BtnPrev.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrev.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrev.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.BtnPrev.IconMarginLeft = 11;
            this.BtnPrev.IconPadding = 10;
            this.BtnPrev.IconRight = null;
            this.BtnPrev.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrev.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrev.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.BtnPrev.IconSize = 25;
            this.BtnPrev.IdleBorderColor = System.Drawing.Color.Empty;
            this.BtnPrev.IdleBorderRadius = 0;
            this.BtnPrev.IdleBorderThickness = 0;
            this.BtnPrev.IdleFillColor = System.Drawing.Color.Empty;
            this.BtnPrev.IdleIconLeftImage = null;
            this.BtnPrev.IdleIconRightImage = null;
            this.BtnPrev.IndicateFocus = false;
            this.BtnPrev.Location = new System.Drawing.Point(456, 6);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.BtnPrev.OnDisabledState.BorderRadius = 25;
            this.BtnPrev.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrev.OnDisabledState.BorderThickness = 1;
            this.BtnPrev.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.BtnPrev.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.BtnPrev.OnDisabledState.IconLeftImage = null;
            this.BtnPrev.OnDisabledState.IconRightImage = null;
            this.BtnPrev.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnPrev.onHoverState.BorderRadius = 25;
            this.BtnPrev.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrev.onHoverState.BorderThickness = 1;
            this.BtnPrev.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.BtnPrev.onHoverState.ForeColor = System.Drawing.Color.White;
            this.BtnPrev.onHoverState.IconLeftImage = null;
            this.BtnPrev.onHoverState.IconRightImage = null;
            this.BtnPrev.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnPrev.OnIdleState.BorderRadius = 25;
            this.BtnPrev.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrev.OnIdleState.BorderThickness = 1;
            this.BtnPrev.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.BtnPrev.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.BtnPrev.OnIdleState.IconLeftImage = null;
            this.BtnPrev.OnIdleState.IconRightImage = null;
            this.BtnPrev.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnPrev.OnPressedState.BorderRadius = 25;
            this.BtnPrev.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.BtnPrev.OnPressedState.BorderThickness = 1;
            this.BtnPrev.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.BtnPrev.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.BtnPrev.OnPressedState.IconLeftImage = null;
            this.BtnPrev.OnPressedState.IconRightImage = null;
            this.BtnPrev.Size = new System.Drawing.Size(102, 25);
            this.BtnPrev.TabIndex = 3;
            this.BtnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnPrev.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.BtnPrev.TextMarginLeft = 0;
            this.BtnPrev.TextPadding = new System.Windows.Forms.Padding(0);
            this.BtnPrev.UseDefaultRadiusAndThickness = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // FrmBookBorrowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 661);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBookBorrowing";
            this.Text = "Borrow Book";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuTextBox txtSearch;
        private Bunifu.UI.WinForms.BunifuDropdown cmbCategory;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.UI.WinForms.BunifuLabel LabelPage;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnNext;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton BtnPrev;
    }
}