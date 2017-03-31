#include <SDL.h>
#include <stdio.h>
#include <string>

// optimize image loading and soft stretching
// expanding an image to the whole surface

const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

void init();
void loadMedia();
void close();

SDL_Surface* loadSurface( std::string path );
SDL_Window* gWindow = NULL;
SDL_Surface* gScreenSurface = NULL;

SDL_Surface* gStretchedSurface = NULL;

void init()
{
		gWindow = SDL_CreateWindow( "", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN );
  	gScreenSurface = SDL_GetWindowSurface( gWindow );
}

void loadMedia()
{
	gStretchedSurface = loadSurface( "../media/stretch.bmp" );
}

void close()
{
	SDL_FreeSurface( gStretchedSurface );
	gStretchedSurface = NULL;
	SDL_DestroyWindow( gWindow );
	gWindow = NULL;
	SDL_Quit();
}

SDL_Surface* loadSurface( std::string path )
{
	SDL_Surface* optimizedSurface = NULL;
	SDL_Surface* loadedSurface = SDL_LoadBMP( path.c_str() );
	optimizedSurface = SDL_ConvertSurface( loadedSurface, gScreenSurface->format, NULL );
	SDL_FreeSurface( loadedSurface );
	return optimizedSurface;
}

int main( int argc, char* args[] )
{
			init();

			loadMedia();

			bool quit = false;

			SDL_Event e;
			while( !quit )
			{
				while( SDL_PollEvent( &e ) != 0 )
				{
					if( e.type == SDL_QUIT )
					{
						quit = true;
					}
				}
				SDL_Rect stretchRect;
				stretchRect.x = 0;
				stretchRect.y = 0;
				stretchRect.w = SCREEN_WIDTH;
				stretchRect.h = SCREEN_HEIGHT;
				SDL_BlitScaled( gStretchedSurface, NULL, gScreenSurface, &stretchRect );
				SDL_UpdateWindowSurface( gWindow );
			}
	close();

	return 0;
}
