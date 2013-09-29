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
            this.tonecorrectionbutton = this.Factory.CreateRibbonButton();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.dicton = this.Factory.CreateRibbonToggleButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.box2 = this.Factory.CreateRibbonBox();
            this.resizepinyin = this.Factory.CreateRibbonButton();
            this.ResizeTones = this.Factory.CreateRibbonButton();
            this.ToneHeightButton = this.Factory.CreateRibbonButton();
            this.box6 = this.Factory.CreateRibbonBox();
            this.pysize = this.Factory.CreateRibbonEditBox();
            this.tnsize = this.Factory.CreateRibbonEditBox();
            this.toneheight = this.Factory.CreateRibbonEditBox();
            this.remove = this.Factory.CreateRibbonButton();
            this.py2tones = this.Factory.CreateRibbonButton();
            this.devel = this.Factory.CreateRibbonGroup();
            this.inspt = this.Factory.CreateRibbonButton();
            this.insxml = this.Factory.CreateRibbonButton();
            this.brackets = this.Factory.CreateRibbonCheckBox();
            this.reins = this.Factory.CreateRibbonButton();
            this.ToneGraphMenu = this.Factory.CreateRibbonMenu();
            this.removeButton = this.Factory.CreateRibbonButton();
            this.pinyinMenu = this.Factory.CreateRibbonMenu();
            this.pinyinMenuA = this.Factory.CreateRibbonMenu();
            this.pinyinMenuO = this.Factory.CreateRibbonMenu();
            this.pinyinMenuE = this.Factory.CreateRibbonMenu();
            this.pinyinMenuI = this.Factory.CreateRibbonMenu();
            this.pinyinMenuU = this.Factory.CreateRibbonMenu();
            this.pinyinMenuV = this.Factory.CreateRibbonMenu();
            this.other = this.Factory.CreateRibbonGroup();
            this.totradbutton = this.Factory.CreateRibbonButton();
            this.tosimpbutton = this.Factory.CreateRibbonButton();
            this.AddTonesRuby = this.Factory.CreateRibbonButton();
            this.AddPinyin = this.Factory.CreateRibbonButton();
            this.undobutton = this.Factory.CreateRibbonButton();
            this.edittnpy = this.Factory.CreateRibbonButton();
            this.tone1button = this.Factory.CreateRibbonButton();
            this.tone2button = this.Factory.CreateRibbonButton();
            this.tone3button = this.Factory.CreateRibbonButton();
            this.tone4button = this.Factory.CreateRibbonButton();
            this.buttona1 = this.Factory.CreateRibbonButton();
            this.buttona2 = this.Factory.CreateRibbonButton();
            this.buttona3 = this.Factory.CreateRibbonButton();
            this.buttona4 = this.Factory.CreateRibbonButton();
            this.buttono1 = this.Factory.CreateRibbonButton();
            this.buttono2 = this.Factory.CreateRibbonButton();
            this.buttono3 = this.Factory.CreateRibbonButton();
            this.buttono4 = this.Factory.CreateRibbonButton();
            this.buttone1 = this.Factory.CreateRibbonButton();
            this.buttone2 = this.Factory.CreateRibbonButton();
            this.buttone3 = this.Factory.CreateRibbonButton();
            this.buttone4 = this.Factory.CreateRibbonButton();
            this.buttoni1 = this.Factory.CreateRibbonButton();
            this.buttoni2 = this.Factory.CreateRibbonButton();
            this.buttoni3 = this.Factory.CreateRibbonButton();
            this.buttoni4 = this.Factory.CreateRibbonButton();
            this.buttonu1 = this.Factory.CreateRibbonButton();
            this.buttonu2 = this.Factory.CreateRibbonButton();
            this.buttonu3 = this.Factory.CreateRibbonButton();
            this.buttonu4 = this.Factory.CreateRibbonButton();
            this.buttonv1 = this.Factory.CreateRibbonButton();
            this.buttonv2 = this.Factory.CreateRibbonButton();
            this.buttonv3 = this.Factory.CreateRibbonButton();
            this.buttonv4 = this.Factory.CreateRibbonButton();
            this.AddTones = this.Factory.CreateRibbonButton();
            this.lookUp = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.config.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
            this.box6.SuspendLayout();
            this.devel.SuspendLayout();
            this.other.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.config);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.devel);
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
            // tonecorrectionbutton
            // 
            this.tonecorrectionbutton.Label = "    Edit Dictionary    ";
            this.tonecorrectionbutton.Name = "tonecorrectionbutton";
            this.tonecorrectionbutton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.tonecorrectionbutton_Click);
            // 
            // label1
            // 
            this.label1.Label = "          ";
            this.label1.Name = "label1";
            // 
            // dicton
            // 
            this.dicton.Label = "          Enable          ";
            this.dicton.Name = "dicton";
            this.dicton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.dicton_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.totradbutton);
            this.group2.Items.Add(this.tosimpbutton);
            this.group2.Label = "Convert";
            this.group2.Name = "group2";
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
            this.group1.Label = "Tones or Pinyin";
            this.group1.Name = "group1";
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
            // devel
            // 
            this.devel.Items.Add(this.inspt);
            this.devel.Items.Add(this.insxml);
            this.devel.Items.Add(this.brackets);
            this.devel.Items.Add(this.reins);
            this.devel.Items.Add(this.ToneGraphMenu);
            this.devel.Items.Add(this.removeButton);
            this.devel.Items.Add(this.pinyinMenu);
            this.devel.Items.Add(this.AddTones);
            this.devel.Label = "Developer";
            this.devel.Name = "devel";
            this.devel.Visible = false;
            // 
            // inspt
            // 
            this.inspt.Label = "Inspect";
            this.inspt.Name = "inspt";
            this.inspt.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.inspt_Click);
            // 
            // insxml
            // 
            this.insxml.Label = "Insert XML";
            this.insxml.Name = "insxml";
            this.insxml.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insxml_Click);
            // 
            // brackets
            // 
            this.brackets.Description = "Turn on Bracket with pinyin output";
            this.brackets.Label = "[Brackets]";
            this.brackets.Name = "brackets";
            // 
            // reins
            // 
            this.reins.Label = "Reinsert";
            this.reins.Name = "reins";
            this.reins.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.reins_Click);
            // 
            // ToneGraphMenu
            // 
            this.ToneGraphMenu.Items.Add(this.tone1button);
            this.ToneGraphMenu.Items.Add(this.tone2button);
            this.ToneGraphMenu.Items.Add(this.tone3button);
            this.ToneGraphMenu.Items.Add(this.tone4button);
            this.ToneGraphMenu.Label = "Tone graph";
            this.ToneGraphMenu.Name = "ToneGraphMenu";
            // 
            // removeButton
            // 
            this.removeButton.Label = "Remove both";
            this.removeButton.Name = "removeButton";
            this.removeButton.ScreenTip = "Removes added tones or pinyin.";
            this.removeButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.removeButton_Click);
            // 
            // pinyinMenu
            // 
            this.pinyinMenu.Items.Add(this.pinyinMenuA);
            this.pinyinMenu.Items.Add(this.pinyinMenuO);
            this.pinyinMenu.Items.Add(this.pinyinMenuE);
            this.pinyinMenu.Items.Add(this.pinyinMenuI);
            this.pinyinMenu.Items.Add(this.pinyinMenuU);
            this.pinyinMenu.Items.Add(this.pinyinMenuV);
            this.pinyinMenu.Label = "Pinyin";
            this.pinyinMenu.Name = "pinyinMenu";
            this.pinyinMenu.ScreenTip = "Insert pinyin vowel with tone graph.";
            // 
            // pinyinMenuA
            // 
            this.pinyinMenuA.Items.Add(this.buttona1);
            this.pinyinMenuA.Items.Add(this.buttona2);
            this.pinyinMenuA.Items.Add(this.buttona3);
            this.pinyinMenuA.Items.Add(this.buttona4);
            this.pinyinMenuA.Label = "a";
            this.pinyinMenuA.Name = "pinyinMenuA";
            this.pinyinMenuA.ScreenTip = "Insert \'a\' with tone graph.";
            this.pinyinMenuA.ShowImage = true;
            // 
            // pinyinMenuO
            // 
            this.pinyinMenuO.Items.Add(this.buttono1);
            this.pinyinMenuO.Items.Add(this.buttono2);
            this.pinyinMenuO.Items.Add(this.buttono3);
            this.pinyinMenuO.Items.Add(this.buttono4);
            this.pinyinMenuO.Label = "o";
            this.pinyinMenuO.Name = "pinyinMenuO";
            this.pinyinMenuO.ScreenTip = "Insert \'o\' with tone graph.";
            this.pinyinMenuO.ShowImage = true;
            // 
            // pinyinMenuE
            // 
            this.pinyinMenuE.Items.Add(this.buttone1);
            this.pinyinMenuE.Items.Add(this.buttone2);
            this.pinyinMenuE.Items.Add(this.buttone3);
            this.pinyinMenuE.Items.Add(this.buttone4);
            this.pinyinMenuE.Label = "e";
            this.pinyinMenuE.Name = "pinyinMenuE";
            this.pinyinMenuE.ScreenTip = "Insert this character.";
            this.pinyinMenuE.ShowImage = true;
            // 
            // pinyinMenuI
            // 
            this.pinyinMenuI.Items.Add(this.buttoni1);
            this.pinyinMenuI.Items.Add(this.buttoni2);
            this.pinyinMenuI.Items.Add(this.buttoni3);
            this.pinyinMenuI.Items.Add(this.buttoni4);
            this.pinyinMenuI.Label = "i";
            this.pinyinMenuI.Name = "pinyinMenuI";
            this.pinyinMenuI.ScreenTip = "Insert \'i\' with tone graph.";
            this.pinyinMenuI.ShowImage = true;
            // 
            // pinyinMenuU
            // 
            this.pinyinMenuU.Items.Add(this.buttonu1);
            this.pinyinMenuU.Items.Add(this.buttonu2);
            this.pinyinMenuU.Items.Add(this.buttonu3);
            this.pinyinMenuU.Items.Add(this.buttonu4);
            this.pinyinMenuU.Label = "u";
            this.pinyinMenuU.Name = "pinyinMenuU";
            this.pinyinMenuU.ScreenTip = "Insert \'u\' with tone graph.";
            this.pinyinMenuU.ShowImage = true;
            // 
            // pinyinMenuV
            // 
            this.pinyinMenuV.Items.Add(this.buttonv1);
            this.pinyinMenuV.Items.Add(this.buttonv2);
            this.pinyinMenuV.Items.Add(this.buttonv3);
            this.pinyinMenuV.Items.Add(this.buttonv4);
            this.pinyinMenuV.Label = "ü";
            this.pinyinMenuV.Name = "pinyinMenuV";
            this.pinyinMenuV.ScreenTip = "Insert this character.";
            this.pinyinMenuV.ShowImage = true;
            // 
            // other
            // 
            this.other.Items.Add(this.lookUp);
            this.other.Label = "Other";
            this.other.Name = "other";
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
            // tone1button
            // 
            this.tone1button.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.tone1button.Label = "1st Tone";
            this.tone1button.Name = "tone1button";
            this.tone1button.ScreenTip = "Insert tone for Chinese character.";
            this.tone1button.ShowImage = true;
            this.tone1button.Tag = "1";
            this.tone1button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertTagAsTone);
            // 
            // tone2button
            // 
            this.tone2button.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.tone2button.Label = "2nd Tone";
            this.tone2button.Name = "tone2button";
            this.tone2button.ScreenTip = "Insert tone for Chinese character.";
            this.tone2button.ShowImage = true;
            this.tone2button.Tag = "2";
            this.tone2button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertTagAsTone);
            // 
            // tone3button
            // 
            this.tone3button.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.tone3button.Label = "3rd Tone";
            this.tone3button.Name = "tone3button";
            this.tone3button.ScreenTip = "Insert tone for Chinese character.";
            this.tone3button.ShowImage = true;
            this.tone3button.Tag = "3";
            this.tone3button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertTagAsTone);
            // 
            // tone4button
            // 
            this.tone4button.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.tone4button.Label = "4th Tone";
            this.tone4button.Name = "tone4button";
            this.tone4button.ScreenTip = "Insert tone for Chinese character.";
            this.tone4button.ShowImage = true;
            this.tone4button.Tag = "4";
            this.tone4button.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertTagAsTone);
            // 
            // buttona1
            // 
            this.buttona1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttona1.Label = "ā";
            this.buttona1.Name = "buttona1";
            this.buttona1.ScreenTip = "Insert this character.";
            this.buttona1.ShowImage = true;
            this.buttona1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttona2
            // 
            this.buttona2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttona2.Label = "á";
            this.buttona2.Name = "buttona2";
            this.buttona2.ScreenTip = "Insert this character.";
            this.buttona2.ShowImage = true;
            this.buttona2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttona3
            // 
            this.buttona3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttona3.Label = "ǎ";
            this.buttona3.Name = "buttona3";
            this.buttona3.ScreenTip = "Insert this character.";
            this.buttona3.ShowImage = true;
            this.buttona3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttona4
            // 
            this.buttona4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttona4.Label = "à";
            this.buttona4.Name = "buttona4";
            this.buttona4.ScreenTip = "Insert this character.";
            this.buttona4.ShowImage = true;
            this.buttona4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttono1
            // 
            this.buttono1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttono1.Label = "ō";
            this.buttono1.Name = "buttono1";
            this.buttono1.ScreenTip = "Insert this character.";
            this.buttono1.ShowImage = true;
            this.buttono1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttono2
            // 
            this.buttono2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttono2.Label = "ó";
            this.buttono2.Name = "buttono2";
            this.buttono2.ScreenTip = "Insert this character.";
            this.buttono2.ShowImage = true;
            this.buttono2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttono3
            // 
            this.buttono3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttono3.Label = "ǒ";
            this.buttono3.Name = "buttono3";
            this.buttono3.ScreenTip = "Insert this character.";
            this.buttono3.ShowImage = true;
            this.buttono3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttono4
            // 
            this.buttono4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttono4.Label = "ò";
            this.buttono4.Name = "buttono4";
            this.buttono4.ScreenTip = "Insert this character.";
            this.buttono4.ShowImage = true;
            this.buttono4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttone1
            // 
            this.buttone1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttone1.Label = "ē";
            this.buttone1.Name = "buttone1";
            this.buttone1.ScreenTip = "Insert this character.";
            this.buttone1.ShowImage = true;
            this.buttone1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttone2
            // 
            this.buttone2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttone2.Label = "é";
            this.buttone2.Name = "buttone2";
            this.buttone2.ScreenTip = "Insert this character.";
            this.buttone2.ShowImage = true;
            this.buttone2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttone3
            // 
            this.buttone3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttone3.Label = "ě";
            this.buttone3.Name = "buttone3";
            this.buttone3.ScreenTip = "Insert this character.";
            this.buttone3.ShowImage = true;
            this.buttone3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttone4
            // 
            this.buttone4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttone4.Label = "è";
            this.buttone4.Name = "buttone4";
            this.buttone4.ScreenTip = "Insert this character.";
            this.buttone4.ShowImage = true;
            this.buttone4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttoni1
            // 
            this.buttoni1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttoni1.Label = "ī";
            this.buttoni1.Name = "buttoni1";
            this.buttoni1.ScreenTip = "Insert this character.";
            this.buttoni1.ShowImage = true;
            this.buttoni1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttoni2
            // 
            this.buttoni2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttoni2.Label = "í";
            this.buttoni2.Name = "buttoni2";
            this.buttoni2.ScreenTip = "Insert this character.";
            this.buttoni2.ShowImage = true;
            this.buttoni2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttoni3
            // 
            this.buttoni3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttoni3.Label = "ǐ";
            this.buttoni3.Name = "buttoni3";
            this.buttoni3.ScreenTip = "Insert this character.";
            this.buttoni3.ShowImage = true;
            this.buttoni3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttoni4
            // 
            this.buttoni4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttoni4.Label = "ì";
            this.buttoni4.Name = "buttoni4";
            this.buttoni4.ScreenTip = "Insert this character.";
            this.buttoni4.ShowImage = true;
            this.buttoni4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonu1
            // 
            this.buttonu1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttonu1.Label = "ū";
            this.buttonu1.Name = "buttonu1";
            this.buttonu1.ScreenTip = "Insert this character.";
            this.buttonu1.ShowImage = true;
            this.buttonu1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonu2
            // 
            this.buttonu2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttonu2.Label = "ú";
            this.buttonu2.Name = "buttonu2";
            this.buttonu2.ScreenTip = "Insert this character.";
            this.buttonu2.ShowImage = true;
            this.buttonu2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonu3
            // 
            this.buttonu3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttonu3.Label = "ǔ";
            this.buttonu3.Name = "buttonu3";
            this.buttonu3.ScreenTip = "Insert this character.";
            this.buttonu3.ShowImage = true;
            this.buttonu3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonu4
            // 
            this.buttonu4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttonu4.Label = "ù";
            this.buttonu4.Name = "buttonu4";
            this.buttonu4.ScreenTip = "Insert this character.";
            this.buttonu4.ShowImage = true;
            this.buttonu4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonv1
            // 
            this.buttonv1.Image = global::Hanzi2TGHZRibbon.Properties.Resources._1;
            this.buttonv1.Label = "ǖ";
            this.buttonv1.Name = "buttonv1";
            this.buttonv1.ScreenTip = "Insert this character.";
            this.buttonv1.ShowImage = true;
            this.buttonv1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonv2
            // 
            this.buttonv2.Image = global::Hanzi2TGHZRibbon.Properties.Resources._2;
            this.buttonv2.Label = "ǘ";
            this.buttonv2.Name = "buttonv2";
            this.buttonv2.ScreenTip = "Insert this character.";
            this.buttonv2.ShowImage = true;
            this.buttonv2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonv3
            // 
            this.buttonv3.Image = global::Hanzi2TGHZRibbon.Properties.Resources._3;
            this.buttonv3.Label = "ǚ";
            this.buttonv3.Name = "buttonv3";
            this.buttonv3.ScreenTip = "Insert this character.";
            this.buttonv3.ShowImage = true;
            this.buttonv3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // buttonv4
            // 
            this.buttonv4.Image = global::Hanzi2TGHZRibbon.Properties.Resources._4;
            this.buttonv4.Label = "ǜ";
            this.buttonv4.Name = "buttonv4";
            this.buttonv4.ScreenTip = "Insert this character.";
            this.buttonv4.ShowImage = true;
            this.buttonv4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.insertLabel);
            // 
            // AddTones
            // 
            this.AddTones.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AddTones.Description = "Add tone graphs to selected text.";
            this.AddTones.Image = global::Hanzi2TGHZRibbon.Properties.Resources.tones;
            this.AddTones.Label = "Add Tones";
            this.AddTones.Name = "AddTones";
            this.AddTones.ScreenTip = "Add tone graphs to selected text.";
            this.AddTones.ShowImage = true;
            this.AddTones.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AddTones_Click);
            // 
            // lookUp
            // 
            this.lookUp.Image = global::Hanzi2TGHZRibbon.Properties.Resources.lookup;
            this.lookUp.Label = "Character Definition";
            this.lookUp.Name = "lookUp";
            this.lookUp.ShowImage = true;
            this.lookUp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.lookUp_Click);
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
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.box6.ResumeLayout(false);
            this.box6.PerformLayout();
            this.devel.ResumeLayout(false);
            this.devel.PerformLayout();
            this.other.ResumeLayout(false);
            this.other.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddTones;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton totradbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tosimpbutton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup devel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton inspt;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton insxml;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AddPinyin;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox brackets;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup config;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuA;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttona1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttona2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttona3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttona4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuO;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttono1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttono2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttono3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttono4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuE;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttone1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttone2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttone3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttone4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttoni1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttoni2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttoni3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttoni4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuU;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonu1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonu2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonu3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonu4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu pinyinMenuV;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonv1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonv2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonv3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonv4;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu ToneGraphMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tone1button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tone2button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tone3button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton tone4button;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton removeButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton reins;
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
    }

    partial class ThisRibbonCollection
    {
        internal RibbonMain RibbonMain
        {
            get { return this.GetRibbon<RibbonMain>(); }
        }
    }
}
