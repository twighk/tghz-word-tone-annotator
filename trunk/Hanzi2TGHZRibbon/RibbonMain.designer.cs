namespace Hanzi2TGHZRibbon
{
    partial class RibbonMain : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonMain()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.config = this.Factory.CreateRibbonGroup();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.other = this.Factory.CreateRibbonGroup();
            this.vlabel = this.Factory.CreateRibbonLabel();
            this.label2 = this.Factory.CreateRibbonLabel();
            this.tonecorrectionbutton = this.Factory.CreateRibbonButton();
            this.dicton = this.Factory.CreateRibbonToggleButton();
            this.AddTonesRuby = this.Factory.CreateRibbonButton();
            this.AddPinyin = this.Factory.CreateRibbonButton();
            this.box1 = this.Factory.CreateRibbonBox();
            this.box2 = this.Factory.CreateRibbonBox();
            this.resizepinyin = this.Factory.CreateRibbonButton();
            this.ResizeTones = this.Factory.CreateRibbonButton();
            this.ToneHeightButton = this.Factory.CreateRibbonButton();
            this.box6 = this.Factory.CreateRibbonBox();
            this.pysize = this.Factory.CreateRibbonEditBox();
            this.tnsize = this.Factory.CreateRibbonEditBox();
            this.toneheight = this.Factory.CreateRibbonEditBox();
            this.undobutton = this.Factory.CreateRibbonButton();
            this.edittnpy = this.Factory.CreateRibbonButton();
            this.remove = this.Factory.CreateRibbonButton();
            this.py2tones = this.Factory.CreateRibbonButton();
            this.color = this.Factory.CreateRibbonButton();
            this.totradbutton = this.Factory.CreateRibbonButton();
            this.tosimpbutton = this.Factory.CreateRibbonButton();
            this.lookUp = this.Factory.CreateRibbonButton();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.tab1.SuspendLayout();
            this.config.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.other.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
            this.box6.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.config);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.other);
            this.tab1.Label = "hanzi2tghz";
            this.tab1.Name = "tab1";
            // 
            // config
            // 
            this.config.Items.Add(this.tonecorrectionbutton);
            this.config.Items.Add(this.label1);
            this.config.Items.Add(this.dicton);
            this.config.Label = "Dictionary Correction";
            this.config.Name = "config";
            // 
            // label1
            // 
            this.label1.Label = "          ";
            this.label1.Name = "label1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.AddTonesRuby);
            this.group1.Items.Add(this.AddPinyin);
            this.group1.Items.Add(this.box1);
            this.group1.Items.Add(this.undobutton);
            this.group1.Items.Add(this.edittnpy);
            this.group1.Items.Add(this.remove);
            this.group1.Items.Add(this.py2tones);
            this.group1.Items.Add(this.buttonGroup1);
            this.group1.Label = "Tones or Pinyin";
            this.group1.Name = "group1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.totradbutton);
            this.group2.Items.Add(this.tosimpbutton);
            this.group2.Label = "Convert";
            this.group2.Name = "group2";
            // 
            // other
            // 
            this.other.Items.Add(this.lookUp);
            this.other.Items.Add(this.label2);
            this.other.Items.Add(this.vlabel);
            this.other.Label = "Other";
            this.other.Name = "other";
            // 
            // vlabel
            // 
            this.vlabel.Label = "Version: 0.xx";
            this.vlabel.Name = "vlabel";
            // 
            // label2
            // 
            this.label2.Label = "                  ";
            this.label2.Name = "label2";
            // 
            // tonecorrectionbutton
            // 
            this.tonecorrectionbutton.Label = "    Edit Dictionary    ";
            this.tonecorrectionbutton.Name = "tonecorrectionbutton";
            this.tonecorrectionbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.tonecorrectionbutton_Click);
            // 
            // dicton
            // 
            this.dicton.Label = "          Enable          ";
            this.dicton.Name = "dicton";
            this.dicton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.dicton_Click);
            // 
            // AddTonesRuby
            // 
            this.AddTonesRuby.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AddTonesRuby.Image = global::Hanzi2TGHZRibbon.Properties.Resources.tones;
            this.AddTonesRuby.Label = "Add Tones";
            this.AddTonesRuby.Name = "AddTonesRuby";
            this.AddTonesRuby.ShowImage = true;
            this.AddTonesRuby.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AddTonesRuby_Click);
            // 
            // AddPinyin
            // 
            this.AddPinyin.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AddPinyin.Description = "Add pinyin to selected text.";
            this.AddPinyin.Image = global::Hanzi2TGHZRibbon.Properties.Resources.pinyin;
            this.AddPinyin.Label = "Add Pinyin";
            this.AddPinyin.Name = "AddPinyin";
            this.AddPinyin.ScreenTip = "Add pinyin to selected text.";
            this.AddPinyin.ShowImage = true;
            this.AddPinyin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AddPinyin_Click);
            // 
            // box1
            // 
            this.box1.Items.Add(this.box2);
            this.box1.Items.Add(this.box6);
            this.box1.Name = "box1";
            // 
            // box2
            // 
            this.box2.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box2.Items.Add(this.resizepinyin);
            this.box2.Items.Add(this.ResizeTones);
            this.box2.Items.Add(this.ToneHeightButton);
            this.box2.Name = "box2";
            // 
            // resizepinyin
            // 
            this.resizepinyin.Label = "Pinyin Resize:";
            this.resizepinyin.Name = "resizepinyin";
            this.resizepinyin.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.resizepinyin_Click);
            // 
            // ResizeTones
            // 
            this.ResizeTones.Label = "Tone Resize: ";
            this.ResizeTones.Name = "ResizeTones";
            this.ResizeTones.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ResizeTones_Click);
            // 
            // ToneHeightButton
            // 
            this.ToneHeightButton.Label = "Tone Height:";
            this.ToneHeightButton.Name = "ToneHeightButton";
            this.ToneHeightButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ResizeTones_Click);
            // 
            // box6
            // 
            this.box6.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box6.Items.Add(this.pysize);
            this.box6.Items.Add(this.tnsize);
            this.box6.Items.Add(this.toneheight);
            this.box6.Name = "box6";
            // 
            // pysize
            // 
            this.pysize.Label = "Pinyin Size:";
            this.pysize.Name = "pysize";
            this.pysize.ShowLabel = false;
            this.pysize.Text = "0.5";
            // 
            // tnsize
            // 
            this.tnsize.Label = "Tone Resize";
            this.tnsize.Name = "tnsize";
            this.tnsize.ShowLabel = false;
            this.tnsize.Text = "1.0";
            // 
            // toneheight
            // 
            this.toneheight.Label = "Tone Height";
            this.toneheight.Name = "toneheight";
            this.toneheight.ShowLabel = false;
            this.toneheight.Text = "10";
            // 
            // undobutton
            // 
            this.undobutton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.undobutton.Image = global::Hanzi2TGHZRibbon.Properties.Resources.undo;
            this.undobutton.Label = "Undo";
            this.undobutton.Name = "undobutton";
            this.undobutton.ShowImage = true;
            this.undobutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.undobutton_Click);
            // 
            // edittnpy
            // 
            this.edittnpy.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.edittnpy.Image = global::Hanzi2TGHZRibbon.Properties.Resources.pencil;
            this.edittnpy.Label = "Edit Tones or Pinyin";
            this.edittnpy.Name = "edittnpy";
            this.edittnpy.ShowImage = true;
            this.edittnpy.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.edittnpy_Click);
            // 
            // remove
            // 
            this.remove.Label = "Remove Tones/Pinyin";
            this.remove.Name = "remove";
            this.remove.ScreenTip = "Remove tonegraphs or pinyin from characters. (Note: It does not remove duplicated" +
                " characters from conversion, use Undo.)";
            this.remove.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.remove_Click);
            // 
            // py2tones
            // 
            this.py2tones.Label = "Pinyin to Tones Graphs";
            this.py2tones.Name = "py2tones";
            this.py2tones.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.py2tones_Click);
            // 
            // color
            // 
            this.color.Label = "Colour";
            this.color.Name = "color";
            this.color.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.color_Click);
            // 
            // totradbutton
            // 
            this.totradbutton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.totradbutton.Image = global::Hanzi2TGHZRibbon.Properties.Resources.fan;
            this.totradbutton.Label = "To Traditional";
            this.totradbutton.Name = "totradbutton";
            this.totradbutton.ScreenTip = "Convert selected text to tradional Chinese.";
            this.totradbutton.ShowImage = true;
            this.totradbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.totradbutton_Click);
            // 
            // tosimpbutton
            // 
            this.tosimpbutton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.tosimpbutton.Image = global::Hanzi2TGHZRibbon.Properties.Resources.jian;
            this.tosimpbutton.Label = "To Simplified";
            this.tosimpbutton.Name = "tosimpbutton";
            this.tosimpbutton.ScreenTip = "Convert selected text to simplified Chinese.";
            this.tosimpbutton.ShowImage = true;
            this.tosimpbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.tosimpbutton_Click);
            // 
            // lookUp
            // 
            this.lookUp.Image = global::Hanzi2TGHZRibbon.Properties.Resources.lookup;
            this.lookUp.Label = "Character Definition";
            this.lookUp.Name = "lookUp";
            this.lookUp.ShowImage = true;
            this.lookUp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.lookUp_Click);
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.color);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // RibbonMain
            // 
            this.Name = "RibbonMain";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonMain_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.config.ResumeLayout(false);
            this.config.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.other.ResumeLayout(false);
            this.other.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.box6.ResumeLayout(false);
            this.box6.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton totradbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tosimpbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddPinyin;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup config;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton undobutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tonecorrectionbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddTonesRuby;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton resizepinyin;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ResizeTones;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box6;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox pysize;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox tnsize;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ToneHeightButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox toneheight;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton edittnpy;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton dicton;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton remove;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton py2tones;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup other;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton lookUp;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel vlabel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton color;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMain RibbonMain
        {
            get { return this.GetRibbon<RibbonMain>(); }
        }
    }
}
