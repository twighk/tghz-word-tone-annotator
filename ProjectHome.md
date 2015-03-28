# Chinese Tones Annotator for Microsoft Word #

A Microsoft Word add-in for adding tone graphs, pinyin or zhuyin to Hanzi（汉字）.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Welcome.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Welcome.png)

The tones are automatically placed above the chinese characters, by the computer using a dictionary ([CC-CEDICT](http://www.mdbg.net/chindict/chindict.php?page=cedict)) for the longest word it can find. If it is unsure of the tones, it will place multiple tones above the character (here 好， as 大家好 is not in the dictionary as one word).

To annotate tones for [LaTeX](http://www.latex-project.org/), see [hanzi2tghz](http://code.google.com/p/hanzi2tghz/).


---


## Installation ##
  1. Download [the installer](https://sourceforge.net/p/tghz-word-tone-annotator/code/HEAD/tree/trunk/Publish/setup.exe?format=raw).
  1. Run the [setup.exe](https://sourceforge.net/p/tghz-word-tone-annotator/code/HEAD/tree/trunk/Publish/setup.exe?format=raw).
  1. Open Word and the hanzi2tghz ribbon should be there.
  1. If any of the previous steps failed, _please_ write about them on the [issues](http://code.google.com/p/tghz-word-tone-annotator/issues/list) page or  [email me](http://www.google.com/recaptcha/mailhide/d?k=01NPKkqVdpvGCxT19t2FK-Zw==&c=nCA8B1q_gIq9ORG1LB4DfW-z0SdUwQXlicZ-lR7pil8=).
  1. Read the documentation, to see what it can do.
  1. Any feedback would be much appreciated. Please write about it on the  [issues](http://code.google.com/p/tghz-word-tone-annotator/issues/list) page or  [email me](http://www.google.com/recaptcha/mailhide/d?k=01NPKkqVdpvGCxT19t2FK-Zw==&c=nCA8B1q_gIq9ORG1LB4DfW-z0SdUwQXlicZ-lR7pil8=).


---


## Documentation ##
Before use, please remember to make a backup of your document, just in case.
### Contents ###
  1. [Tones, Pinyin or Zhuyin Fuhao](https://code.google.com/p/tghz-word-tone-annotator/#Tones,_Pinyin_or_Zhuyin_Fuhao)
    1. [Adding](https://code.google.com/p/tghz-word-tone-annotator/#Adding)
    1. [Removing](https://code.google.com/p/tghz-word-tone-annotator/#Removing)
    1. [Editing](https://code.google.com/p/tghz-word-tone-annotator/#Editing)
  1. [Resizing Text](https://code.google.com/p/tghz-word-tone-annotator/#Resizing_Text)
  1. [Dictionary Correction](https://code.google.com/p/tghz-word-tone-annotator/#Dictionary_Correction)
    1. [Enabling Dictionary Correction](https://code.google.com/p/tghz-word-tone-annotator/#Enabling_Dictionary_Correction)
    1. [Editing the Corrections Dictionary](https://code.google.com/p/tghz-word-tone-annotator/#Editing_the_Corrections_Dictionary)
    1. [Importing and Exporting](https://code.google.com/p/tghz-word-tone-annotator/#Importing_and_Exporting)
  1. [Colouring Tones](https://code.google.com/p/tghz-word-tone-annotator/#Colouring_Tones)
  1. [Converting Traditional/Simplified Characters](https://code.google.com/p/tghz-word-tone-annotator/#Converting_Traditional/Simplified_Characters)
  1. [Troubleshooting](https://code.google.com/p/tghz-word-tone-annotator/#Troubleshooting)
    1. [Certificate Error](https://code.google.com/p/tghz-word-tone-annotator/#Certificate_Error)
    1. [Visual Studio Tools for Office Solution Installer Error](https://code.google.com/p/tghz-word-tone-annotator/#Visual_Studio_Tools_for_Office_Solution_Installer_Error)
    1. [Other Problems](https://code.google.com/p/tghz-word-tone-annotator/#Other_Problems)

### Tones, Pinyin or Zhuyin Fuhao ###
![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Tones%20or%20Pinyin.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Tones%20or%20Pinyin.png)

#### Adding ####
To add tones or pinyin to text select some, or all the text (`Ctrl+a`), and press either the `Add Tones`, `Add Pinyin` or `Add Zhuyin` Button. When the dictionary finds multiple pronunciations for tones it puts multiple tones. For Pinyin or Zhuyin, it duplicates the words with the various pronuciations. To reduce duplicates use the Dictionary Correction utilities.

When tones or pinyin are added, all the font information about the text before is lost, so the size, colour, font, etc. are reset to the default.

#### Removing ####
When removing tones or pinyin, it is preferable to use the `undo` button, to undo the previous action of adding them. For tones, the `Remove Tones/Pinyin` button can be used, but it can be problematic for pinyin, as it does not remove the duplicated characters caused by converting to pinyin.

#### Editing ####
To edit tones or pinyin, click on or select some text, then press the `Edit Tones or Pinyin` button and the incorrectly named `Edit Text or Pinyin` window should appear.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/EditTextOrPinyin.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/EditTextOrPinyin.png)

Here 大家好 has tones, and 欢迎来到我的网站 has pinyin. For tones, put the number of the tone or tones, in the text box on the right. For pinyin put the pinyin followed by the tone number.





### Resizing Text ###
When the text is resized the tone/pinyin do not scale with the text size. The solution is to use one of the `resize` buttons.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Resize.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Resize.png)

#### Pinyin or Zhuyin Fuhao ####
To resize pinyin or zhuyin fuhao, use the `Pinyin Resize:` button. The number next to it (`0.5` is the default) is the relative size of the text compared to the characters, i.e. `0.5` is half the size, `1.0` is the same size.

#### Tones ####
For Tones there are two issues the size of the tones and the height of the tones above the characters. For the size of the tones use the `Tone Resize:` button and change the relative size if you wish. For the height of the tones, change the number next to the `Tone Height:` button (`12` is the default, make it larger for larger text), then click the `Tone Height:` button.




### Dictionary Correction ###
#### Enabling Dictionary Correction ####
To enable dictionary correction press the `Enable` button in the `Dictionary Corrections` Section of the toolbar/Ribbon. By default there are no corrections, you can see the avaliable corrections, by pressing the `Edit Dictionary` in the `Dictionary Corrections` section. To import a tone corrections dictionary, or make yourown, see below.

#### Editing the Corrections Dictionary ####
To open the Dictionary Corrections window press the `Edit Dictionary` button.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/DictionaryCorrections.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/DictionaryCorrections.png)

Press the `Done` button to close the window saving changes.
##### Adding Words #####
To add a correction, type the chinese characters in the box containing `汉字` and the pinyin, separated by character by spaces, postfixed with the tone graph number, in the `han4 zi4` box. Then press the `Add` button and it should be copied into the list. See the above window for examples.

For multiple pronuciations add the same chinese characters twice, with different pronunciations.

##### Deleting Words #####
To delete words, select the large grey box to the left of the row you wish to delete, and press the delete key. There is no button in the window to do this.

##### Editing Words #####
The words in the dictionary cannot be edited, to preven errors in the program. To edit one delete it, and add the corrected version.

##### Enabling/Disabling Words #####
Words can be enabled or disabled individually, buy having the tickbox checked or unchecked, respectively.


#### Importing and Exporting ####
Edits to the dictionary can be imported or exported, to enable sharing, by selecting an option in the `File` Menu.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/DictionaryCorrectionsImportExport.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/DictionaryCorrectionsImportExport.png)

Currently there is no undo mechanism for this. The tone corrections file is a hidden file called `tghzToneCorrections.txt` in your personal user or home folder. The file can be backed up by exporting it (see below) or making a duplicate. Deleting this file should cause a new empty file.

##### Importing #####
To import a tone corrections file, press the `Edit Dictionary` button, and then `File -> Import Dictionary Corrections File` from the menu bar in the `Dictionary Corrections` window. A file dialog box will appear allowing you to choose the file to import. Please be careful to select the correct file.

Here is my [Tone Corrections File](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/toneCorrections.txt). To download it, right-click the hyperlink and choose `Save Link As...`, or similar.

##### Exporting #####
To export a tone corrections file, press the `Edit Dictionary` button, and then `File -> Export Dictionary Corrections File` from the menu bar in the `Dictionary Corrections` window. A file dialog box will appear allowing you to choose where to export the file to.

### Colouring Tones ###
Tones/pinyin and/or characters can be coloured using the colour button. Tick the box(es) before adding tones or pinyin for the output to also be coloured.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Welcome%20Color.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/Welcome%20Color.png)




### Converting Traditional/Simplified Characters ###
To convert from traditional or simplified to simplified or traditional, select the text and press the `To Simplified` or `To Traditional` buttons, respectively.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/TraditionalSimplified.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/TraditionalSimplified.png)


### Troubleshooting ###
If you have any problems, please feel free to [email me](http://www.google.com/recaptcha/mailhide/d?k=01NPKkqVdpvGCxT19t2FK-Zw==&c=nCA8B1q_gIq9ORG1LB4DfW-z0SdUwQXlicZ-lR7pil8=).

#### Certificate Error ####
While running the setup file there may be a certificate error:

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/certerror.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/certerror.png)

, because it is installing from an untrusted location.

To fix this, `https://tghz-word-tone-annotator.googlecode.com` needs to be added to the list of trusted sites:

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/certerrorfix.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/certerrorfix.png)

Open Internet Explorer, and click the `Gear Icon` (top right corner) and then choose `Internet Options`. In the `Internet Options` window select `Security`, then `Trusted Sites`, then click the button that says `Sites`. In the `Trusted sites` window copy and paste:

`https://tghz-word-tone-annotator.googlecode.com`

and `Add` it. It should now be possible to install the program.

### Visual Studio Tools for Office Solution Installer Error ###
While running the setup file, there may be an error message with the `Visual Studio Tools for Office Solution Installer`.

![https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/VSTOInstaller.png](https://tghz-word-tone-annotator.googlecode.com/svn/trunk/Images/VSTOInstaller.png)

To fix this, please run the setup program as an administrator.

(This problem was seen on Windows 8.1)

### Other Problems ###
If there are any other problems with using or installing the software, please [email me](http://www.google.com/recaptcha/mailhide/d?k=01NPKkqVdpvGCxT19t2FK-Zw==&c=nCA8B1q_gIq9ORG1LB4DfW-z0SdUwQXlicZ-lR7pil8=) or [submit an issue](http://code.google.com/p/tghz-word-tone-annotator/issues/list).