
  function   ShowFolderFileList(folderspec)
  {
        var   fso,   f,   f1,   fc,   s;
        fso   =   new   ActiveXObject("Scripting.FileSystemObject");
        f   =   fso.GetFolder(folderspec);
        fc   =   new   Enumerator(f.files);
        s   =   "";
        for   (;   !fc.atEnd();   fc.moveNext())
        {
              s   +=   "<a href='"+fc.item()+"'>"+fc.item()+"</a>";
              s   +=   "<br>";
        }
        return(s);
  }
