# __Notepad / Analogue program WordPad__

05.03.2021
---
Makarshina Anastasia
Applied math
1 course
group 09-021
---
_The task_

 Provide opportunities:
 - [x] editing text files (insert, delete characters, line feed);
 - [x] saving the typed text (by default in UTF-8 encoding, optionally with the choice of the desired encoding);
 - [x] opening a text file (by default in UTF-8 encoding, optionally with the choice of the desired encoding);
 - [x] highlight the specified text in bold, italic, change the font color of a part of the text, change the font size of a part of the text;
 - [x] optionally prints the file.
 - [x] Create a main menu with access to the File items (New, Open, Save, Exit);
 - [x] Font (change color, size, bold / italic);
 - [x] Help (About the program).
 - [x] Optionally, you can add the Edit menu item to work with the buffer (cut, copy, paste)

## Annotation
The program is implemented in the C #, Windows Forms programming language.
Development environment - Visual Studio.
The program was developed as an analogue of a standard notepad with all the necessary functions.

[Full listing of the program](https://github.com/makarstasia/Notepad)

Technical details

Basic methods.

* working with a file:

  file creation:
   ``` public void CreateDocument(object sender, EventArgs arg) ``` 

  creates a new document with empty name and text + method called to check for changes in the file
   ``` UpdateName() ```

  accidental closure case provided
   ``` SaveUnSave() ```
 
  open file:  
  ``` public void OpenFile(object sender, EventArgs arg) ```

  save file:
  ``` public void Save(object sender, EventArgs arg) ```

  there is a method for saving in a different encoding 
  ``` private void uTF32ToolStripMenuItem_Click(object sender, EventArgs e)//UTF16 LE ```

  print:
  ``` private void печатьToolStripMenuItem_Click(object sender, EventArgs e) ```

  closing the program: 
  ``` private void выходToolStripMenuItem_Click(object sender, EventArgs e) ```

  note: when the text is changed, a * 
  ``` (метод private void OnTextChange(object sender, EventArgs arg) ) ```


* work with text:

  copy:
  ``` public void CopyText() ```
  
  cut out:
  ``` public void CutText() ```
  
  insert:
  ``` public void PaяsteText() ```

  jump to the desired line: 
  ``` private void перейтиToolStripMenuItem_Click(object sender, EventArgs e) ```
  
  font changes: 
  ``` private void шрифтToolStripMenuItem_Click(object sender, EventArgs e) ```
  
  information about the program:
   ``` private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) ```


