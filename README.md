This is a content analysis programm written in C# for Windows (because win Forms are used here).

It counts the number of entered paired symbol sequences found in the document. The supported types of documents are *.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm.

First it does decodes the document, after the main loop counts the symbol sequences entrances in the whole document line by line 
based on average number of words in the sentance.

After the first word in the words pair is found (The symbol sequence in the text contains the first word) the algorythm starts to search for the second one in the distance of
average number of words in the sentance using the same logic.

