// checks if file or directory exists

import java.io.File;

File filename = new File("directory\\filepath\\");

if(filename.exists() && !filename.isDirectory()) {
  System.out.println("exists");
}
else {
  System.out.println("does not exist");
}
