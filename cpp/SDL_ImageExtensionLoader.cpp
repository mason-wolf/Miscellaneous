#include <SDL.h>
#include <SDL_image.h>
#include <stdio.h>
#include <string>

// extension libraries and loading other formats, loading a png

const int SCREEN_WIDTH = 640;
const int SCREEN_HEIGHT = 480;

void init();
void loadMedia();
void close();

SDL_Surface* loadSurface( std::string path );
SDL_Window* gWindow = NULL;
SDL_Surface* gScreenSurface = NULL;
SDL_Surface* gPNGSurface = NULL;

void init()
{
		gWindow = SDL_CreateWindow( "", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN );
		gScreenSurface = SDL_GetWindowSurface( gWindow );
}

void loadMedia()
{
	gPNGSurface = loadSurface( "../media/png.png" );
}

void close()
{
	SDL_FreeSurface( gPNGSurface );
	gPNGSurface = NULL;
	SDL_DestroyWindow( gWindow );
	gWindow = NULL;
	IMG_Quit();
	SDL_Quit();
}

SDL_Surface* loadSurface( std::string path )
{
	SDL_Surface* optimizedSurface = NULL;
	SDL_Surface* loadedSurface = IMG_Load( path.c_str() );
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
				SDL_BlitSurface( gPNGSurface, NULL, gScreenSurface, NULL );
				SDL_UpdateWindowSurface( gWindow );
		}
	close();
	return 0;
}
